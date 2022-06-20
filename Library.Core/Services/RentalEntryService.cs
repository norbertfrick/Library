using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.Events;
using Library.Core.Settings;
using Microsoft.Extensions.Configuration;

namespace Library.Core.Services
{
    public class RentalEntryService : IRentalEntryService
    {
        private Dictionary<eTitleType, int> DayToRentDictionary = new Dictionary<eTitleType, int>();

        private Dictionary<eTitleType, decimal> DailyPenaltyFee = new Dictionary<eTitleType, decimal>();

        private readonly IRentalEntryRepository _repository;

        private readonly IBookRepository _bookRepository;

        private readonly IDvdRepository _dvdRepository;

        private readonly IQueueService _queueService;

        private event EventHandler<TitleReturnedEventArgs> TitleReturned;

        public RentalEntryService(IConfiguration config, IRentalEntryRepository repository, IBookRepository books, IDvdRepository dvds, IQueueService queueService)
        {
            this._repository = repository;
            this._bookRepository = books;
            this._dvdRepository = dvds;
            this._queueService = queueService;


            InitializeConstants(config);

            InitializeEventSubscriptions();

        }

        private void InitializeConstants(IConfiguration settings)
        {
            this.DayToRentDictionary = new Dictionary<eTitleType, int>()
            {
                { eTitleType.Book, int.Parse(settings.GetSection("GeneralSettings:BookRentalDays").Value)},
                { eTitleType.Dvd, int.Parse(settings.GetSection("GeneralSettings:DvdRentalDays").Value)}
            };

            this.DailyPenaltyFee = new Dictionary<eTitleType, decimal>()
            {
                { eTitleType.Book, decimal.Parse(settings.GetSection("GeneralSettings:BookDailyFee").Value)},
                { eTitleType.Dvd, decimal.Parse(settings.GetSection("GeneralSettings:DvdDailyFee").Value)},

            };
        }

        private void InitializeEventSubscriptions()
        {
            this.TitleReturned += _queueService.OnTitleReturned;
        }

        public List<RentalEntry> GetAllEntries()
        {
            return this._repository.GetAll().ToList();
        }

        public List<RentalEntry> GetRentalEntriesPastDue()
        {
            var notReturnedEntries = this._repository.Find(e => e.ReturnDate == null);

            var result = new List<RentalEntry>();

            foreach (var entry in notReturnedEntries)
            {
                if (IsEntryPastDue(entry))
                    result.Add(entry);

            }

            return result;
        }

        public List<RentalEntry> GetByUnreturnedMember(int memberId)
        {
            return this._repository.Find(m => m.MemberId == memberId && m.ReturnDate == null).ToList();
        }

        public bool IsEntryPastDue(RentalEntry entry)
        {
            return DateTime.Now.Date < entry.RentedDate.AddDays(DayToRentDictionary.GetValueOrDefault(entry.TitleType));
        }

        public decimal CalculateReturnalFee(RentalEntry entry)
        {
            if (!IsEntryPastDue(entry))
                return 0;

            var dateDifference = (DateTime.Now - entry.RentedDate).Days;

            var result = dateDifference * DailyPenaltyFee.GetValueOrDefault(entry.TitleType);

            return result;
        }

        public RentalEntry Rent(Title title, Member member)
        {
            //updateAvailableCopies
            UpdateAvailableTitleCopies(title, eTitleCountUpdate.Remove);

            var entry = new RentalEntry();

            entry.TitleId = title.Id;
            entry.MemberId = member.Id;
            entry.TitleType = title is Book ? eTitleType.Book : eTitleType.Dvd;

            entry.RentedDate = DateTime.Now.Date;

            entry.TimesProlongued = 0;

            var result = _repository.Create(entry);

            return result;
        }

        private void UpdateAvailableTitleCopies(Title title, eTitleCountUpdate action)
        {
            var isBook = title is Book;
            Title entity = isBook ? _bookRepository.GetById(title.Id) : _dvdRepository.GetById(title.Id);

            if (action == eTitleCountUpdate.Add)
                entity.AvailableCopies++;
            else entity.AvailableCopies--;


            if (isBook)
                _bookRepository.Update(title.Id, entity as Book);
            else _dvdRepository.Update(title.Id, entity as Dvd);
        }

        public RentalEntry Return(RentalEntry entry)
        {
            //updateAvailableCopies
            UpdateAvailableTitleCopies(entry.Title, eTitleCountUpdate.Add);

            entry.ReturnDate = DateTime.UtcNow;

            this._repository.Update(entry.Id, entry);

            //titleReturnedEvent
            if (this.TitleReturned is not null)
                this.TitleReturned(this, new TitleReturnedEventArgs(entry.Title));

            return entry;
        }
    }
}
