using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class RentalEntryService : IRentalEntryService
    {
        private readonly IRentalEntryRepository _repository;

        public RentalEntryService(IRentalEntryRepository repository)
        {
            this._repository = repository;
        }

        public List<RentalEntry> GetAllEntries()
        {
            return this._repository.GetAll().ToList();
        }

        public List <RentalEntry> GetByMember(int memberId)
        {
            return this._repository.Find(m => m.MemberId == memberId).ToList();
        }

        public RentalEntry Rent(Title title, Member member)
        {
            var entry = new RentalEntry();

            entry.Title = title;
            entry.Member = member;

            entry.RentedDate = DateTime.Now.Date;

            entry.TimesProlongued = 0;

            var result = _repository.Create(entry);

            return result;
        }

        public RentalEntry Return(RentalEntry entry)
        {
            entry.ReturnDate = DateTime.UtcNow;

            this._repository.Update(entry.Id, entry);

            return entry;
        }
    }
}
