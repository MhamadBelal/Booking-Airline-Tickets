using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem
{
    public class ScheduleTrip
    {
        [Key]
        public String TripName { get; set; }
        [Required]
        [Display(Name ="From")]
        public String PlaceFrom { get; set; }
        [Required]
        [Display(Name ="To")]
        public String PlaceTo { get; set; }
        [Required]
        [Display(Name = "the expected time for Depature")]
        public String Depature_Time { get; set; }
        [Required]
        [Display(Name = "the expected time for Arrival")]
        public String Arrival_Time { get; set; }
        [Range(1,460)]
        [Display(Name ="the number of passenger")]
        public int NoP { get; set; }
        [Display(Name = "the expected Duration time")]
        public String Duration { get; set; }
        public virtual List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
