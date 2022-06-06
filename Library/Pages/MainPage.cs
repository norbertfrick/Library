using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.UI.Base;
using Library.UI.Helpers;

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
