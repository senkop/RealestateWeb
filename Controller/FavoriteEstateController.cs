using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
//using FoodApi.Models;
//using FoodApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Try.BL.Interface;
using Try.DAL.Database;
using Try.DAL.Entity;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    //    [Authorize]
    public class FavoriteEstateController : ControllerBase
    {
        private DbContainer _dbContext;
      
        public FavoriteEstateController(DbContainer dbContext)
        {
            _dbContext = dbContext;
        
        }



        [HttpGet("{userId}")]
       // public async Task<List<FavoriteEstate>> Get(string userId)
        public ActionResult SearchFavotiteList(string userId ) 

        {


            //  try
            //  {
            //Users u = _dbContext.Users.ToList().Where(n => (n.Id == userId)).SingleOrDefault();

            //if (u != null)
            //{
            //List<FavoriteEstate> list = _dbContext.FavoriteEstates.Where(n => n.UsersId == userId).ToList();


            //return Ok(list);
            //1312ea68-d159-4746-b6e6-d5d41431c7e3

            //    var reservations = from reservation in _dbContext.FavoriteEstates
            //                       join customer in _dbContext.Users on reservation.UsersId equals customer.Id
            //                       join movie in _dbContext.Estates on reservation.EstateId equals movie.IdEstate
            //                       select new
            //                       {
            //                           Id = reservation.EstateId,
            //                           location=reservation.Estates.Location
            //                           //ReservationTime = reservation.ReservationTime,
            //                           //CustomerName = customer.Id,
            //                           //MovieName = movie.Name
            //                       };
            //    return Ok(reservations);
            //}
            //var x = _dbContext.Estates;
            var fav = (from s in _dbContext.FavoriteEstates.Where(s => s.UsersId == userId)
                       join p in _dbContext.Estates on s.EstateId equals p.IdEstate

                       select new
                       {

                        //   Estate = s.Estates,
                           //UserId=userId,

                           IdEstate = s.EstateId,
                           Price = s.Estates.Price,
                           CompanyName = s.Estates.CompanyName,
                           Rooms_numbers = s.Estates.Rooms_numbers,
                           Location = s.Estates.Location,
                           cover = s.Estates.cover,
                           rent = s.Estates.rent,
                           Bathroom_numbers = s.Estates.Bathroom_numbers,
                           Buy = s.Estates.Buy,
                           Type = s.Estates.Type,
                           City = s.Estates.City,
                           size = s.Estates.size,
                           State = s.Estates.State,
                           Street = s.Estates.Street,
                           St_num = s.Estates.St_num,
                           Description = s.Estates.Description,
                           Floors_numbers = s.Estates.Floors_numbers,
                           image1 = s.Estates.image1,
                           image2 = s.Estates.image2,
                           image3 = s.Estates.image3,
                           Garden = s.Estates.Garden,



                       }).ToList();
            //// //_dbContext.SaveChangesAsync();
            //// //_dbContext.Entry(shoppingCartItems).CurrentValues.SetValues(shoppingCartItems);

            return Ok(fav);

            }
            //var cart =  _dbContext.FavoriteEstates
            //            .Where(c => c.UsersId == userId)
            //            .Include(u => u.Users)
            //            .Include(b => b.Estates)
            //            .ToListAsync();

            //                else
            //                {
            //                    return NotFound();
            //    //                }

            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            internal async Task<IList<FavoriteEstate>> GetCartFromUser(string userId)
        {
            return await _dbContext.FavoriteEstates
                .Include(c => c.Estates)
                .Where(c => c.UsersId == userId)
                .ToListAsync();
        }


        // POST: api/ShoppingCartItems
        [HttpPost("{userId},{estateid}")]
        public ActionResult AddToFavorite(string userId, int estateid/*, int num*/)
        {
            try
            {
                Users u = _dbContext.Users.ToList().Where(n => (n.Id == userId)).SingleOrDefault();
                if (u != null)
                {
                    //购物车中是否存在该物品
                    FavoriteEstate cart = _dbContext.FavoriteEstates.Where(n => n.EstateId == estateid && n.UsersId == u.Id).SingleOrDefault();
                    //存在就添加数量
                    //if (cart != null)
                    //{
                    //    cart.Num += num;
                    //    _dbContext.SaveChanges();
                    //}
                    //否则就新增
                    //else
                    //{
                    cart = new FavoriteEstate();
                    cart.UsersId = u.Id;
                    // cart.Num = num;
                    cart.EstateId = estateid;
                    _dbContext.FavoriteEstates.Add(cart);
                    _dbContext.SaveChanges();
                    //}
                    return Ok("Success");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{userId},{estateid}")]
        public IActionResult Delete(string userId,  int estateid)
        {
            // Shopcart cart = _dbContext.Shopcart.Where(n => n.ApartmentId == apartmentid && n.UsersId == u.Id).SingleOrDefault();
            var shoppingCart = _dbContext.FavoriteEstates.Where(s => s.EstateId == estateid);
            _dbContext.FavoriteEstates.RemoveRange(shoppingCart);
            _dbContext.SaveChanges();
            return Ok();


           
        }
    }
}
