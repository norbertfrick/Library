﻿using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class MessagingService : IMessagingService
    {

        private readonly IMessageRepository _messageRepository;

        public MessagingService(IMessageRepository repo)
        {
            this._messageRepository = repo;
        }

        public List<Message> GetMessagesForUser(int userId)
        {
            var result = this._messageRepository.Find(m => m.MemberId == userId).ToList();

            return result;
        }

        public bool SendMessage(int memberId, string subject, string message)
        {
            var msg = new Message();

            msg.MemberId = memberId;
            msg.MessageSubject = subject;
            msg.MessageContent = message;
            msg.SendDate = DateTime.UtcNow;

            var result = this._messageRepository.Create(msg);

            return result is not null;
        }
    }
}
