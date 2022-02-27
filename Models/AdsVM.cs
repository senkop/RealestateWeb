using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Try.DAL.Entity;

namespace Try.Models
{
    public class AdsVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = " min len 3")]
        [MaxLength(50, ErrorMessage = "max len 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "enter Description")]
       
        public string Description { get; set; }
        
        public Users Users { get; set; }
    }
}
