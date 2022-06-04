using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Message Create(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
