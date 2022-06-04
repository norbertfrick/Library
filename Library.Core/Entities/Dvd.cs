using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Dvd: Title
    {
        [Required]
        public int LengthInMinutes { get; set; }

        [Required]
        public int NumberOfChapters { get; set; }
    }
}
