using Library.Core.Abstractions;
using Library.Core.Entities;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Members
{
    internal class RemoveMemberPage: MenuPageBase
    {
        private const string PAGE_HEADER = "Remove member page";

        internal RemoveMemberPage(Application app): base(PAGE_HEADER, app)
        {
            this._memberRepository = app.Services.GetService<IMemberRepository>();

            InitializeOptions();
        }

        private readonly IMemberRepository _memberRepository;

        public override void Display()
        {
            base.Display();

            OutputHelper.WriteLine("Choose a member to delete:");
            this.Menu.Display();
        }

        private void DeleteMember(Member member)
        {
            try
            {
                var result = this._memberRepository.Delete(member.Id);

                if (result is null)
                    OutputHelper.WriteLine("Member not deleted.");
                else OutputHelper.WriteLine("Member deleted successfully.");
            }
            catch (Exception ex)
            {
                OutputHelper.WriteLine("Member deleted successfully.");
            }
            finally
            {
                InputHelper.ReadKey("Press any key to return to Members page...");
            }

            this.Application.NavigateBack();
        }

        private void InitializeOptions()
        {
            var members = GetMembers();

            for(int index = 0; index < members.Count; index++)
                this.Menu.Add(new Option(index + 1, members[index].ToString(), () => this.DeleteMember(members[index])));

        }

        private List<Member> GetMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }
    }
}
