using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Base
{
    internal abstract class PageBase
    {
        public PageBase(string title, Application app)
        {
            this.Title = title;
            this.Application = app;
        }
        
        public string Title { get; set; }

        public Application Application { get; set; }
        
        public virtual void Display()
        {
            Console.WriteLine(Title);
        }

    }
}
