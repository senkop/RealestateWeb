using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Try.Models
{
    public class EmployeeViewModel
    {
     
            [Required(ErrorMessage = "Please enter first name")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter last name")]
            [Display(Name = "First Name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Please enter age")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Please choose gender")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Please enter position")]
            public string Position { get; set; }

            [Required(ErrorMessage = "Please enter office")]
            public string Office { get; set; }

            [Required(ErrorMessage = "Please enter salary")]
            public int Salary { get; set; }

            [Required(ErrorMessage = "Please choose profile image")]
            [Display(Name = "Profile Picture")]
            public IFormFile ProfileImage { get; set; }
        }


    
}
