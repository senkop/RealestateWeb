using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Try.Api.Services;
using Try.Configuration;
using Try.DAL.Database;
using Try.DAL.Entity;
using Try.Models;
using Try.Models.DTOs.Requests;
using Try.Models.DTOs.Responses;
using Try.Services;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")] // api/authManagement
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly JwtConfig _jwtConfig;
        //   private readonly TokenValidationParameters _tokenValidationParams;
        private readonly DbContainer _apiDbContext;
        private readonly SignInManager<Users> _signInManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthManagementController> _logger;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public AuthManagementController(
            UserManager<Users> userManager,
            // RoleManager<IdentityRole> roleManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            SignInManager<Users> signInManager,
          // TokenValidationParameters tokenValidationParams,
          ILogger<AuthManagementController> logger,
          IUserService userService, IMailService mailService, IConfiguration configuration,
            DbContainer apiDbContext)
        {
            _logger = logger;
            //_roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            //_tokenValidationParams = tokenValidationParams;
            _apiDbContext = apiDbContext;
            _userService = userService;
            _mailService = mailService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                // We can utilise the model
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Email already in use"
                            },
                        Success = false
                    });
                }

                var newUser = new Users() { Email = user.Email, UserName = user.Username, FirstName = user.FistName, LastName = user.LastName, PhoneNumber = user.phone };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);

                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken,
                          userid = newUser.Id,
                        email = newUser.Email

                    });
                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
               //return Ok(  await _userManager.GetUserIdAsync(existingUser));
               var x = await _userManager.GetUserIdAsync(existingUser);

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false

                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
              //  return Ok(_userManager.GetUserIdAsync(existingUser));
                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false

                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);

                //return new AuthenticateResponse(existingUser, jwtToken);
                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken,
                    userid = existingUser.Id,
                    email=existingUser.Email



                }
                ); ;
               //var x =_userManager.GetUserIdAsync(existingUser))

            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });

        }
        
        public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Users user, string token)
        {
            Id= user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            //Username = user.Username;
            Token = token;
        }
    }
        [HttpPost("logout")]
      //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //[HttpPost]
        //[Route("ForgetPassword")]
        //public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPassword", "AuthManagement", new { Email = model.Email, Token = token }, Request.Scheme);

        //            MailHelper.sendMail("Password Reset Link", passwordResetLink);

        //            _logger.Log(LogLevel.Warning, passwordResetLink);

        //            // return RedirectToAction("ResetPassword");
        //            return Ok();
        //        }

        //        //return RedirectToAction("ResetPassword");
        //        return Ok();

        //    }

        //    return Ok(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

        //            if (result.Succeeded)
        //            {
        //                // return RedirectToAction("ConfirmResetPassword");
        //                return Ok();
        //            }

        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }

        //            return Ok(model);
        //        }

        //       // return RedirectToAction("ConfirmResetPassword");
        //    }
        //    return Ok(model);
        //}
      //  api/auth/forgetpassword
       [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _userService.ForgetPasswordAsync(email);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordVM model)
        {
            // api/auth/resetpassword

            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
        public static class MailHelper
        {
            public static string sendMail(string Title, string Message)
            {
                try
                {

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.EnableSsl = true;

                    smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");


                    smtp.Send("as8338873@gmail.com", "mostafakhaled72@gmail.com", Title, Message);

                    return "Mail Sent Successfully";

                    //MailMessage m = new MailMessage();

                    //m.From = "";
                    //m.To = "";
                    //m.Subject = "";
                    //m.Body = "";
                    //m.CC = "";
                    //m.Attachments = "";

                }
                catch (Exception ex)
                {
                    return "Mail Faild";
                }
            }
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}