    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Try.Models
{
    public class ResetPasswordVM
    {
    //    [Required(ErrorMessage = "Mail Required")]
    //    [EmailAddress(ErrorMessage = "You Must Enter Valid Mail")]
    //    public string Email { get; set; }



    //    public string UserId { get; set; }



    //    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    //    public string Code { get; set; }
     [Required(ErrorMessage = "Mail Required")]
    [EmailAddress(ErrorMessage = "You Must Enter Valid Mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password Required")]
    [DataType(DataType.Password)]
    [MinLength(3, ErrorMessage = "Min Len 3")]
    public string Password { get; set; }


    [Required(ErrorMessage = "Password Required")]
    [DataType(DataType.Password)]
    [MinLength(3, ErrorMessage = "Min Len 3")]
    [Compare("Password", ErrorMessage = "Not Matching")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    public string Token { get; set; }

}
}

