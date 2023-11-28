using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Try.Models
{
    public class EstateViewModel
    {

        public Boolean Garden { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public Double size { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Rooms_numbers { get; set; }
        public int Bathroom_numbers { get; set; }
        public string CompanyName { get; set; }
        public int St_num { get; set; }
        public Double Price { get; set; }
        public int Floors_numbers { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public Boolean Buy { get; set; }
        public Boolean rent { get; set; }
        public string Type { get; set; }
        public string image1 { get; set; }
        public IFormFile Image1 { get; set; }
        public string image2 { get; set; }
        public IFormFile Image2 { get; set; }
        public string image3 { get; set; }
        public IFormFile Image3 { get; set; }

        public string cover { get; set; }
        public IFormFile CoverImage { get; set; }

    }


    
}
