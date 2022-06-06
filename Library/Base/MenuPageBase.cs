using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Base
{
    internal abstract class MenuPageBase : PageBase
    {
        public MenuPageBase(string title, Application app) : base(title, app)
        {
            this.Menu = new Menu();
        }

        protected Menu Menu { get; set; }

        public override void Display()
        {
            base.Display();
        }
    }
}
