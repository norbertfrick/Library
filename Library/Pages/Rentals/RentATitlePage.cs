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

namespace Library.UI.Pages.Rentals
{
    internal class RentATitlePage: MenuPageBase
    {
        private const string PAGE_HEADER = "Rent a title";
        public RentATitlePage(Application app) : base(PAGE_HEADER, app)
        {
            this._rentalEntryService = app.Services.GetService<IRentalEntryService>();
            this._memberRepository = app.Services.GetService<IMemberRepository>();
            this._bookRepository = app.Services.GetService<IBookRepository>();
            this._dvdRepository = app.Services.GetService<IDvdRepository>();
            this._queueService = app.Services.GetService<IQueueService>();

            InitializeMenu();
        }

        private readonly IRentalEntryService _rentalEntryService;

        private readonly IMemberRepository _memberRepository;

        private readonly IBookRepository _bookRepository;
        
        private readonly IDvdRepository _dvdRepository;

        private readonly IQueueService _queueService;

        private Menu _chooseTitleMenu = new Menu();

        private Menu _chooseMemberMenu = new Menu();

        private Title _choosenTitle;

        private Member _choosenMember;

        private void InitializeMenu()
        {
            var members = GetAllMembers();

            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                _chooseMemberMenu.Add(i + 1, members[i].ToString(), () => this._choosenMember = member);
            }


            var titles = GetAllTitles();

            for (int i = 0; i < titles.Count; i++)
            {
                var title = titles[i];
                _chooseTitleMenu.Add(i + 1, titles[i].ToString(), () => this._choosenTitle = title);

            }
        }

        public override void Display()
        {
            base.Display();

            OutputHelper.WriteLine("Choose a member to rent to:", ConsoleColor.Blue);
            this._chooseMemberMenu.Display();

            Console.Clear();

            OutputHelper.WriteLine("Choose a title to rent to:", ConsoleColor.Blue);
            this._chooseTitleMenu.Display();

            this.RentATitle();

            InputHelper.ReadKey("Press any key to continue...");
            this.Application.NavigateBack();
        }

        private List<Member> GetAllMembers()
        {
            return _memberRepository.GetAll().ToList();
        }

        private List<Title> GetAllTitles()
        {
            var list = new List<Title>();

            list.AddRange(this._dvdRepository.GetAll());
            list.AddRange(this._bookRepository.GetAll());

            return list;
        }

        private void RentATitle()
        {
            var title = this._choosenTitle;
            var member = this._choosenMember;

            //check title availability
            if (!IsTitleAvailable(title))
            {
                ShowQueuePrompt(title, member);

                this.Application.NavigateBack();
            }

            var result = _rentalEntryService.Rent(title, member);

            if (result is null)
            {
                OutputHelper.WriteLine("Title not rented ", ConsoleColor.Red);
            }
            else OutputHelper.WriteLine("Title rented successfully.", ConsoleColor.Green);

        }

        private bool IsTitleAvailable(Title title)
        {
            var isBook = title is Book ? true : false;

            return isBook ? this._bookRepository.IsBookAvailable(title.Id) : this._dvdRepository.IsDvdAvailable(title.Id);
        }

        private void ShowQueuePrompt(Title title, Member member)
        {
            var menu = new Menu();

            menu.Add(1, "Yes", () => AddToQueue(title, member));
            menu.Add(2, "No", () => { return;});

            OutputHelper.WriteLine("Do you want to add your inquiry to the queue?");
            menu.Display();
        }
        
        private bool AddToQueue(Title title, Member member)
        {
            var result = this._queueService.AddToQueue(title, member);

            return result is not null;
        }

    }
}
