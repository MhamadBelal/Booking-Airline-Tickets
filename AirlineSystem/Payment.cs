using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem
{
    public class Payment
    {   
        [Key]
        [StringLength(16)]
        public String CardId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Card Name")]
        public String NameCard { get; set; }
        [Required]
        public String EndDate { get; set; }
        public int Money { get; set; }
        [Required]
        [StringLength(3)]
        public String CVV { get; set; }
        [Required]
        [Display(Name ="User Name")]
        [ForeignKey(nameof(users))]
        public int UserId { get; set; } 
        public virtual User users { get; set; }
    }
}
