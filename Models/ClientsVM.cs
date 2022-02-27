using Try.DAL.Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Try.Models
{
    public class ClientsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first  Name")]
        [MinLength(3, ErrorMessage = " min len 3")]
        [MaxLength(50, ErrorMessage = "max len 50")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Enter second Name")]
        [MinLength(3, ErrorMessage = " min len 3")]
        [MaxLength(50, ErrorMessage = "max len 50")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Enter Email ")]
        [RegularExpression("[0-9][a-zA-Z]{3,50}@[0-9][a-zA-Z]{3,50}.[a-zA-Z]{3,3}", ErrorMessage = "Enter like example@example.com")]
        public string Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime Signupdate { get; set; }
        public virtual ICollection<Client_interesets> Client_Interesets { get; set; }
        public virtual ICollection<Client_orders> Client_Orders { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
