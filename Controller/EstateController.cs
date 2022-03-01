using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try.BL.Interface;

namespace Try.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateRep estate;

        public EstateController(IEstateRep estate)
        {
            this.estate = estate;

            //sharedLocalizer = SharedLocalizer;

           
        }
        [HttpGet]
        public IActionResult Index(int PageIndex, int PageSize)
        {

            //var data = employee.Get().Skip(3).Take(3);
            var data = estate.Get();

            return Ok(data);
        }
        //[HttpGet]
        //public IActionResult GetById(int id)
        //{

        //    //var data = employee.Get().Skip(3).Take(3);
        //    var data = estate.Get();

        //    return Ok(data);
        //}
    }
}
