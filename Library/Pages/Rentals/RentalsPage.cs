using Library.Core.Abstractions;
using Library.UI.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Rentals
{
    internal class RentalsPage: MenuPageBase
    {
        private const string PAGE_HEADER = "Rentals page";

        public RentalsPage(Application app): base(PAGE_HEADER, app)
        {
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            this.Menu.Add(1, "Rent a title", () => this.Application.NavigateTo<RentATitlePage>());
            this.Menu.Add(2, "Return a title", () => this.Application.NavigateTo<ReturnTitlePage>());
            this.Menu.Add(3, "Show all rentals", () => this.Application.NavigateTo<AllRentalsPage>());
            this.Menu.Add(4, "Back", () => this.Application.NavigateBack());
        }

        public override void Display()
        {
            base.Display();

            this.Menu.Display();
        }

    }
}
