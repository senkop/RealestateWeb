using Try.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.Models
{
    public class Client_interesetsVM
    {
        public int Id { get; set; }
        public int Clientsid { get; set; }
        
        public Clients Clients { get; set; }
        public int Interestsid { get; set; }
     
        public Interests Interests { get; set; }
    }
}
