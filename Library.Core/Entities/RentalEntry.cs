using Library.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class RentalEntry : EntityBase
    {
        public Member Member { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public DateTime RentedDate { get; set; }
        [Required]
        public DateTime? ReturnDate { get; set; }
        public Title Title { get; set; }
        [Required]
        public int TitleId { get; set; }
        
        public int TimesProlongued { get; set; }
        
        public bool IsReturned => this.ReturnDate is not null;

        public override string ToString()
        {
            return $"{Title.Name} - {Title.Author} - Rented on: {RentedDate.ToShortDateString()} - Returned: {(!IsReturned ? "NOT RETURNED" : ReturnDate.Value.ToShortDateString())} - Times prolongued: {TimesProlongued}";
        }
    }
}
