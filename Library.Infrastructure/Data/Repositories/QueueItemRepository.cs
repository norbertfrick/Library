using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class QueueItemRepository : IQueueItemRepository
    {
        public QueueItem Create(QueueItem entity)
        {
            throw new NotImplementedException();
        }

        public QueueItem Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QueueItem> Find(Expression<Func<QueueItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QueueItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public QueueItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, QueueItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
