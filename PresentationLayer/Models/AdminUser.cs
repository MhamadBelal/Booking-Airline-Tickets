﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class AdminUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Gender { get; set; }
        public string RoleName { get; set; }


    }
}