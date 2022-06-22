﻿using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly LibraryContext _context;

        public MessageRepository(LibraryContext context)
        {
            this._context = context;
        }

        public Message Create(Message entity)
        {
            var member = this._context.Messages.Add(entity);

            this._context.SaveChanges();

            return member.Entity;
        }

        public Message Delete(int id)
        {
            var member = this.GetById(id);

            if (member is null) return null;

            var result = this._context.Messages.Remove(member);
            this._context.SaveChanges();

            return result.Entity;
        }

        public IEnumerable<Message> Find(Expression<Func<Message, bool>> expression)
        {
            return this._context.Messages.Where(expression);
        }

        public IEnumerable<Message> GetAll()
        {
            return this._context.Messages;
        }

        public Message GetById(int id)
        {
            var result = this._context.Messages.FirstOrDefault(m => m.Id == id);

            return result;
        }

        public void Update(int id, Message entity)
        {
            this._context.Messages.Update(entity);

            this._context.SaveChanges();
        }
    }
}
