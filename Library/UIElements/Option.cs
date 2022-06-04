using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    internal class Option
    {
        public string Name { get; set; }

        public Action Callback { get; private set; }

        public int Ordinal { get; set; }

        public Option(int ordinal, string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }


    }
}
