using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using Try.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Try.DAL.Entity;

namespace Try.Models
{
    public class EstatesVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
   
        public string Location { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int St_num { get; set; }
        public Double Price { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public string Filter { get; set; }
        public int Usersid { get; set; }
      

       public Users Users { get; set; }
        public int Propertiesid { get; set; }
        
      public Properties Properties { get; set; }

    }
}
