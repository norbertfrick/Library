using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Settings
{
    public class GeneralSettings
    {
        public int BookRentalDays { get; set; }

        public int DvdRentalDays { get; set; }

        public decimal BookDailyFee { get; set; }
        
        public decimal DvdDailyFee { get; set; }
    }
}
