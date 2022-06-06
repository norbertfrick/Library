﻿using Library.UI.Base;
using Library.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages
{
    internal class TitlesPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Titles";

        internal TitlesPage(Application app) : base(PAGE_HEADER, app)
        {
            InitializeOptions();
        }

        private void InitializeOptions()
        {
            this.Menu.Add(1, "Show All Titles", () => this.Application.NavigateTo<AllTitlesPage>());
            this.Menu.Add(2, "Add Title", () => this.Application.NavigateTo<AddTitlePage>());
            this.Menu.Add(3, "Remove Title", () => this.Application.NavigateTo<RemoveTitlePage>());
            this.Menu.Add(4, "Back", () => this.Application.NavigateHome());
        }

        public override void Display()
        {
            base.Display();

            this.Menu.Display();
        }
    }
}
