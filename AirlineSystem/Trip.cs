using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem
{
    public class Trip
    {
        [Key]
        public String TripId { get; set; }
        [Range(1,460)]
        [Display(Name = "Avaliable sets")]
        public int Avaliable { get; set; }
        [Required]
        [Display(Name = "The Acual Depature Time")]
        public string Acual_depature { get; set; }
        [Required]
        [Display(Name = "The Acual Arrival Time")]
        public string Acual_Arrival { get; set; }
        [Display(Name = "The Acual Duration Time")]
        public string Acual_Duration { get; set; }
        [Required]
        public String Date { get; set; }
        [Required]
        public int price { get; set; }
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
        [Required]
        [Display(Name ="TripName")]
        [ForeignKey(nameof(Sced))]
        public String TripName { get; set; }
        public virtual ScheduleTrip Sced { get; set; }
    }
}
