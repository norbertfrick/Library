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

namespace Library.UI.Pages.Rentals
{
    internal class ReturnTitlePage: MenuPageBase
    {
        private const string PAGE_HEADER = "Return title";
        public ReturnTitlePage(Application app) : base(PAGE_HEADER, app)
        {
            this._rentEntryService = app.Services.GetService<IRentalEntryService>();
            this._memberRepository = app.Services.GetService<IMemberRepository>();
        }

        private readonly IRentalEntryService _rentEntryService;

        private readonly IMemberRepository _memberRepository;

        private Menu _chooseMemberMenu = new Menu();

        private Menu _chooseTitleMenu = new Menu();

        public override void Display()
        {
            base.Display();

            InitializeMembersMenu();

            OutputHelper.WriteLine("Choose a member: ", ConsoleColor.Blue);
            _chooseMemberMenu.Display();

            Console.Clear();
            OutputHelper.WriteLine("Select a title to return:", ConsoleColor.Blue);
            
            _chooseTitleMenu.Display();

            InputHelper.ReadKey("Press any key to return to Rental page...");
        }


        private void InitializeMembersMenu()
        {
            var members = GetAllMembers();

            for (var i = 0; i < members.Count; i++)
                _chooseMemberMenu.Add(i + 1, members[i].ToString(), () => InitializeRentEntriesMenu(members[i]));

        }

        private void InitializeRentEntriesMenu(Member member)
        {
            var rentEntries = this._rentEntryService.GetByMember(member.Id);

            for (var i = 0; i < rentEntries.Count; i++)
                _chooseMemberMenu.Add(i + 1, rentEntries[i].ToString(), () => ReturnTitle(rentEntries[i]));
        }

        private void ReturnTitle(RentalEntry entry)
        {
            //isLateCheck

            //feeCalculation

            var result = this._rentEntryService.Return(entry);

            OutputHelper.WriteLine("Title returned successfully", ConsoleColor.Green);
        }

        private List<Member> GetAllMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }

    }
}
