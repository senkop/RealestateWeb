using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Try.DAL.Entity
{
    public class Client_interesets
    {
        [Key]
        public int Id { get; set; }
        public int Clientsid { get; set; }
        [ForeignKey("Clientsid")]
        public Clients Clients { get; set; }
        public int Interestsid { get; set; }
        [ForeignKey("Interestsid")]
        public Interests Interests { get; set; }
    }
}
