﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.UI.Base;
using Library.UI.Helpers;
using Library.UI.Pages.Members;
using Library.UI.Pages.Rentals;

namespace Library.UI.Pages
{
    internal class MainPage: MenuPageBase
    {
        private const string MAIN_PAGE_CONST = "Main Page";

        internal MainPage(Application app): base(MAIN_PAGE_CONST, app)
        {
            InitializeMenuOptions();
        }

        private void InitializeMenuOptions()
        {
            this.Menu.Add(1, "Titles", () => this.Application.NavigateTo<TitlesPage>());
            this.Menu.Add(2, "Members", () => this.Application.NavigateTo<MembersPage>());
            this.Menu.Add(3, "Rentals", () => this.Application.NavigateTo<RentalsPage>());
            this.Menu.Add(4, "Exit", () => this.Application.Exit());

        }

        public override void Display()
        {
            OutputHelper.WriteLine("****Welcome to our Library****");
            base.Display();
            OutputHelper.WriteLine("\n");

            this.Menu.Display();
        }
    }
}
