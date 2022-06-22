using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Messages
{
    internal class MessagesPage: MenuPageBase
    {
        private const string PAGE_HEADER = "Messages";

        internal MessagesPage(Application app): base(PAGE_HEADER, app)
        {
            this._service = app.Services.GetService<IMessagingService>();
            this._members = app.Services.GetService<IMemberRepository>();
        }

        private readonly IMessagingService _service;

        private readonly IMemberRepository _members;

        private void InitializeMenu()
        {
            var members = GetAllMembers();

            for(int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                Menu.Add(i + 1, $"{members[i].FirstName} {members[i].LastName}", () => ShowMessagesForMember(member));
            }
        }

        private void ShowMessagesForMember(Member member)
        {
            OutputHelper.Clear();

            var messages = this._service.GetMessagesForUser(member.Id);

            if (messages.Count == 0) 
            {
                OutputHelper.WriteLine("No messages to display...");
                return;
            }

            var sb =  new StringBuilder();
            foreach (var message in messages)
                sb.AppendLine($"Sent: {message.SendDate} - Subject: {message.MessageSubject}{Environment.NewLine}{Environment.NewLine}{message.MessageContent}{Environment.NewLine}");

            OutputHelper.WriteLine(sb.ToString());
        }

        private List<Member> GetAllMembers()
        {
            return _members.GetAll().ToList();
        }

        public override void Display()
        {
            base.Display();
            this.InitializeMenu();

            Menu.Display();

            InputHelper.ReadKey("Press any key to return to Main menu...");
            this.Application.NavigateBack();
        }

        

    }
}
