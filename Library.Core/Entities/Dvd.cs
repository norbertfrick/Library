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

        public override string ToString()
        {
            return $"Name:{this.Name} - Author:{this.Author} - Number of chapters:{this.NumberOfChapters} - Length:{this.LengthInMinutes}min - Avaiable copies:{this.AvailableCopies}";
        }
    }
}
