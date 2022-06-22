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

            OutputHelper.Clear();
            OutputHelper.WriteLine("Select a title to return:", ConsoleColor.Blue);
            
            _chooseTitleMenu.Display();

            InputHelper.ReadKey("Press any key to return to Rental page...");

            this.Application.NavigateBack();
        }


        private void InitializeMembersMenu()
        {
            var members = GetAllMembers();

            for (var i = 0; i < members.Count; i++)
            {
                var member = members[i];
                _chooseMemberMenu.Add(i + 1, members[i].ToString(), () => InitializeRentEntriesMenu(member));
            }

        }

        private void InitializeRentEntriesMenu(Member member)
        {
            var rentEntries = this._rentEntryService.GetByUnreturnedMember(member.Id);

            for (var i = 0; i < rentEntries.Count; i++)
            {
                var entry = rentEntries[i];
                _chooseTitleMenu.Add(i + 1, rentEntries[i].ToString(), () => ReturnTitle(entry));

            }
        }

        private void ReturnTitle(RentalEntry entry)
        {
            //isLateCheck
            if (this._rentEntryService.IsEntryPastDue(entry))
            {
                OutputHelper.WriteLine("You are late with the returning of this title!", ConsoleColor.Red);

                //feeCalculation
                var fee = this._rentEntryService.CalculateReturnalFee(entry);

                OutputHelper.WriteLine($"The fee for your late returnal is: {fee}Euro", ConsoleColor.Red);

                InputHelper.ReadKey("Press any key to continue...");
            }

            var result = this._rentEntryService.Return(entry);

            OutputHelper.WriteLine("Title returned successfully", ConsoleColor.Green);
        }

        private List<Member> GetAllMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }

    }
}
