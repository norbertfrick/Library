using Library.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Message: EntityBase
    {
        public Member Member { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string MessageContent { get; set; }
        [Required]
        public string MessageSubject { get; set; }
        [Required]
        public DateTime SendDate { get; set; }

    }
}
