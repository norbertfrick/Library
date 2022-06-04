using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book: Title
    {
        [Required]
        public int NumberOfPages { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
