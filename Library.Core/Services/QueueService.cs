using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using Library.Core.Events;

namespace Library.Core.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueItemRepository _repository;

        public QueueService(IQueueItemRepository repo)
        {
            this._repository = repo;
        }

        public QueueItem AddToQueue(Title title, Member member)
        {
            var queueItem = new QueueItem();

            queueItem.TitleId = title.Id;
            queueItem.MemberId = member.Id;
            queueItem.TimeAdded = DateTime.UtcNow;

            return this._repository.Create(queueItem);
        }

        public void MarkAsResolved(QueueItem item)
        {
            item.IsResolved = true;

            this._repository.Update(item.Id, item);
        }

        public List<QueueItem> GetAllItems()
        {
            return this._repository.GetAll().ToList();
        }

        public void OnTitleReturned(object sender, TitleReturnedEventArgs args)
        {
            var queueItems = _repository.Find(i => i.TitleId == args.Title.Id && i.IsResolved == false);
            var title = queueItems.OrderBy(i => i.TimeAdded).LastOrDefault();

            MarkAsResolved(title);
        }
    }
}
