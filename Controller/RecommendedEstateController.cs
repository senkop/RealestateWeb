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

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    //    [Authorize]
    public class RecommendedEstateController : ControllerBase
    {
        private DbContainer _dbContext;

        public RecommendedEstateController(DbContainer dbContext)
        {
            _dbContext = dbContext;

        }



        [HttpGet("{userId}")]
        //public async Task<List<Apartments>> Get(string userId)
        public ActionResult SearchRecommendedlist(string userId)
        {




            var shoppingCartItems = (from s in _dbContext.RecommendedEstates.Where(s => s.UsersId == userId)
                                     join p in _dbContext.Estates on s.EstateId equals p.IdEstate


                                     select new /*FavoriteEstate*/
                                     {
                                         IdEstate = s.EstateId,
                                         Price = s.Estate.Price,
                                         CompanyName = s.Estate.CompanyName,
                                         Rooms_numbers = s.Estate.Rooms_numbers,
                                         Location = s.Estate.Location,
                                         cover = s.Estate.cover,
                                         rent = s.Estate.rent,
                                         Bathroom_numbers = s.Estate.Bathroom_numbers,
                                         Buy = s.Estate.Buy,
                                         Type = s.Estate.Type,
                                         City = s.Estate.City,
                                         size = s.Estate.size,
                                         State = s.Estate.State,
                                         Street = s.Estate.Street,
                                         St_num = s.Estate.St_num,
                                         Description = s.Estate.Description,
                                         Floors_numbers = s.Estate.Floors_numbers,
                                         image1 = s.Estate.image1,
                                         image2 = s.Estate.image2,
                                         image3 = s.Estate.image3,
                                         Garden = s.Estate.Garden,




                                     }  ).ToList();
            return Ok(shoppingCartItems);
        }
    
        //try
        //{
        //    Users u = _dbContext.Users.ToList().Where(n => (n.Id == userId)).SingleOrDefault();

        //    if (u != null)
        //    {
        //        List<RecommendedEstate> list = _dbContext.RecommendedEstates.Where(n => n.UsersId == userId).ToList();
        //        return Ok(list);
        //    }

        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(ex.Message);
        //}

        // POST: api/ShoppingCartItems
        [HttpPost("{userId},{estateid}")]
        public ActionResult AddToRecommended(string userId, int estateid/*, int num*/)
        {
            try
            {
                Users u = _dbContext.Users.ToList().Where(n => (n.Id == userId)).SingleOrDefault();
                if (u != null)
                {
                    //购物车中是否存在该物品
                    RecommendedEstate cart = _dbContext.RecommendedEstates.Where(n => n.EstateId == estateid && n.UsersId == u.Id).SingleOrDefault();
                    //存在就添加数量
                    //if (cart != null)
                    //{
                    //    cart.Num += num;
                    //    _dbContext.SaveChanges();
                    //}
                    //否则就新增
                    //else
                    //{
                    cart = new RecommendedEstate();
                    cart.UsersId = u.Id;
                    // cart.Num = num;
                    cart.EstateId = estateid;
                    _dbContext.RecommendedEstates.Add(cart);
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
        [HttpDelete("{userId}")]
        public IActionResult Delete(string userId, int estateid)
        {
            // Shopcart cart = _dbContext.Shopcart.Where(n => n.ApartmentId == apartmentid && n.UsersId == u.Id).SingleOrDefault();
            var shoppingCart = _dbContext.RecommendedEstates.Where(s => s.EstateId == estateid);
            _dbContext.RecommendedEstates.RemoveRange(shoppingCart);
            _dbContext.SaveChanges();
            return Ok();



        }
    }
}
