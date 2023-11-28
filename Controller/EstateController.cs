using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Try.BL.Helper;
using Try.DAL.Entity;
using Try.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Try.DAL.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Try.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {

        private readonly DbContainer dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public static int PAGE_SIZE { get; set; } = 5;


        public bool HasValue { get; }

        public EstateController(DbContainer context, IWebHostEnvironment hostEnvironment)
        {

            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> New([FromForm] EstateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName1 = UploadedFile1(model);
                string uniqueFileName2 = UploadedFile2(model);
                string uniqueFileName3 = UploadedFile3(model);
                string uniqueFileName4 = UploadedFile4(model);

                Estate estate = new Estate
                {
                    Garden = model.Garden,
                    Location = model.Location,
                    State = model.State /*+ " " + model.LastName*/,
                    size = model.size,
                    City = model.City,
                    Street = model.Street,
                    St_num = model.St_num,
                    Price = model.Price,
                    Floors_numbers = model.Floors_numbers,
                    Description = model.Description,
                    Bathroom_numbers = model.Bathroom_numbers,
                    Rooms_numbers = model.Rooms_numbers,
                    CompanyName = model.CompanyName,
                    Buy = model.Buy,
                    rent = model.rent,
                    Type = model.Type,
                    image1 = uniqueFileName1,
                    image2 = uniqueFileName2,
                    image3 = uniqueFileName3,
                    cover = uniqueFileName4,
                };
                dbContext.Add(estate);
                await dbContext.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Ok();
            }
            return Ok();
        }

        private string UploadedFile4(EstateViewModel model)
        {
            string uniqueFileName4 = null;
            if (model.CoverImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images2");
                uniqueFileName4 = Guid.NewGuid().ToString() + "_" + model.CoverImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName4);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CoverImage.CopyTo(fileStream);
                }

            }
            return uniqueFileName4;
        }
        private string UploadedFile1(EstateViewModel model)
        {
            string uniqueFileName1 = null;
            // string uniqueFileName2 = null;

            if (model.Image1 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images2");
                uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Image1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image1.CopyTo(fileStream);
                }

            }
            return uniqueFileName1;
        }
        private string UploadedFile2(EstateViewModel model)
        {
            string uniqueFileName2 = null;
            // string uniqueFileName2 = null;

            if (model.Image2 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images2");
                uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Image2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image1.CopyTo(fileStream);
                }

            }
            return uniqueFileName2;
        }
        private string UploadedFile3(EstateViewModel model)
        {
            string uniqueFileName3 = null;
            // string uniqueFileName2 = null;

            if (model.Image3 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images2");
                uniqueFileName3 = Guid.NewGuid().ToString() + "_" + model.Image3.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName3);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image3.CopyTo(fileStream);
                }

            }
            return uniqueFileName3;
        }
        [HttpGet("{type},{city},{price_from},{price_to},{size_from},{size_to}")]
        public async Task<ActionResult<IEnumerable<Estate>>> GetApartments1(string type, string city, double price_from, double price_to, double size_from, double size_to, int page = 1)

        {
            var allProducts = dbContext.Estates.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                allProducts = allProducts.Where(hh => hh.Type.Contains(type));
            }
            if (!string.IsNullOrEmpty(city))
            {
                allProducts = allProducts.Where(hh => hh.City.Contains(city));
            }



            //   allProducts = allProducts.Where(hh => hh.State.Contains(city));

            allProducts = allProducts.Where(hh => hh.Price >= price_from);

            allProducts = allProducts.Where(hh => hh.Price <= price_to);

            allProducts = allProducts.Where(hh => hh.size >= size_from);

            allProducts = allProducts.Where(hh => hh.size <= size_to);

            var result = PaginatedList<Try.DAL.Entity.Estate>.Create(allProducts, page, PAGE_SIZE);

            result.Select(hh => new Estate
            {
                City = hh.City,
                Location = hh.Location,
                Price = hh.Price,
             image1 = hh.image1,
              image2 = hh.image2,
              image3 = hh.image3,
              cover = hh.cover

                //TenLoai = hh.Loai?.TenLoai
            }).ToList();
            try
            {

                return Ok(result);
            }
            catch
            {
                //return BadRequest("We can't get the product.");
                return await dbContext.Estates.ToListAsync();


            }

        }
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; set; }
            public int TotalPage { get; set; }

            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPage = (int)Math.Ceiling(count / (double)pageSize);
                AddRange(items);
            }

            public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
            {
                var count = source.Count();
                var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> GetApartment(int id)
        {
            var apartment = await dbContext.Estates
                
                .SingleOrDefaultAsync(s => s.IdEstate == id);

            if (apartment == null)
            {
                return NotFound();
            }

            return apartment;
        }

        //  PUT: api/Stadia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartment(int id, Estate apartment)
        {
            if (id != apartment.IdEstate)
            {
                return BadRequest();
            }

            dbContext.Entry(apartment).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool EstateExists(int id)
        {
            return dbContext.Estates.Any(e => e.IdEstate == id);
        }
        //public IActionResult Registration()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Registration(RegistrationVM model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var user = new IdentityUser()
        //        {
        //            UserName = model.Email,
        //            Email = model.Email
        //        };

        //        var result = await userManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Login");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }


        //    }

        //    return Ok(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM model)//<Ads>> PostAds(Ads ads)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemomberMe, false);

        //        if (result.Succeeded)
        //        {

        //            // return Ok();
        //           // return CreatedAtAction("GetEstate", new { id = estate.Id }, estate);
        //            //var token = GenerateToken(identityUser);
        //            //return Ok(new { Token = token, Message = "Success" });


        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid UserName Or Password Attempt");

        //        }


        //    }

        //    return Ok(model);
        //}

        //public IActionResult ForgetPassword()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

        //            MailHelper.sendMail("Password Reset Link", passwordResetLink);

        //            logger.Log(LogLevel.Warning, passwordResetLink);

        //            return RedirectToAction("ConfirmForgetPassword");
        //        }

        //        return RedirectToAction("ConfirmForgetPassword");

        //    }

        //    return Ok(model);
        //}



        //public IActionResult ConfirmForgetPassword()
        //{
        //    return Ok();
        //}

        //public IActionResult ResetPassword(string Email, string Token)
        //{
        //    if (Email == null || Token == null)
        //    {
        //        ModelState.AddModelError("", "Invalid Data");
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("ConfirmResetPassword");
        //            }

        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }

        //            return Ok(model);
        //        }

        //        return RedirectToAction("ConfirmResetPassword");
        //    }

        //    return Ok(model);
        //}


        //public IActionResult ConfirmResetPassword()
        //{
        //    return Ok();
        //}



    }
}

