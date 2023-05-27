using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        [ForeignKey(nameof(trips))]
        public String TripId { get; set; }
        public virtual Trip trips { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [ForeignKey(nameof(users))]
        public int UserId { get; set; }
        public virtual User users { get; set; }
    }
}
