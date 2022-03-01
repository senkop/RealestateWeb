using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try.BL.Interface;
using Try.DAL.Database;
using Try.Models;

namespace Try.BL.Repo
{
    public class EstateRep : IEstateRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;


        public EstateRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }


        public void Add(EstatesVM est)
        {
         ;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(EstatesVM est)
        {
            throw new NotImplementedException();
        }
        
        public IQueryable<EstatesVM> Get()

        {
            IQueryable<EstatesVM> data = GetAllEstates();
            return data;
            //throw new NotImplementedException();
        }
        
        public EstatesVM GetById(int id)
        {
            EstatesVM data = GetEstatesByID(id);
            return data;
        }

        private IQueryable<EstatesVM> GetAllEstates()
        {
            return db.Estate
                       .Select(a => new EstatesVM { Id = a.Id, State = a.State, City = a.City, Street = a.Street, St_num = a.St_num, Price = a.Price, Location = a.Location, Description = a.Description, Filter = a.Filter, ImageName = a.ImageName,Usersid=a.Users.Id , Propertiesid =a.Properties.Id});
        }
        private EstatesVM GetEstatesByID(int id)
        {
            return db.Estate.Where(a=>a.Id==id)
                      .Select(a => new EstatesVM { Id = a.Id, State = a.State, City = a.City, Street = a.Street, St_num = a.St_num, Price = a.Price, Location = a.Location, Description = a.Description, Filter = a.Filter, ImageName = a.ImageName, Usersid = a.Users.Id, Propertiesid = a.Properties.Id })
                        .FirstOrDefault();
        }

        }
}
