using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class UserPayment
    {
        public string username { get; set; }
        public string cardIdPayment { get; set; }
        public string password { get; set; }
        public string CardName { get; set; }
        public string endDate { get; set; }
        public string CVV { get; set; }
        public int money { get; set; }
    }
}