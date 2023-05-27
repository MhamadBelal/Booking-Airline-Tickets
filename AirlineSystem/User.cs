using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name="User Fullname")]
        public String Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Range(18,150)]
        [Required]
        public int Age { get; set; }
        public String Address { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        public String PhoneNo { get; set; }
        [Required]
        public String Gender { get; set; }
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual List<Payment> Payments { get; set; } = new List<Payment>();
        [Required]
        [ForeignKey(nameof(UserRole))]
        public int RoleId { get; set; }
        public virtual Role UserRole { get; set; }
    }

    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
