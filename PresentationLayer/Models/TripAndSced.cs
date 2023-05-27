using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class TripAndSced
    {
        public string TripId { get; set; }
        public int AvaliableSets { get; set; }
        public string Acual_depature { get; set; }
        public string Acual_Arrival { get; set; }
        public string Acual_Duration { get; set; }
        public string DateTrip { get; set; }
        public int priceTrip { get; set; }
        public string TripName { get; set; }
        public string PlaceFrom { get; set; }
        public string placeTo { get; set; }
    }
}