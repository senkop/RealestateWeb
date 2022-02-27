using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("Clients")]
    public class Clients
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Fname { get; set; }
        [StringLength(50)]
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime Signupdate { get; set; }
        public virtual ICollection<Client_interesets> Client_Interesets { get; set; }
        public virtual ICollection<Client_orders> Client_Orders { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
