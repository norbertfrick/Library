using Library.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Member: EntityBase
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonalId { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
