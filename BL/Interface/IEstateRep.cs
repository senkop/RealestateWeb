using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try.Models;
namespace Try.BL.Interface
{
   public interface IEstateRep
    {
        IQueryable<EstatesVM> Get();
        EstatesVM GetById(int id);
        void Add(EstatesVM est);
        void Edit(EstatesVM est);
        void Delete(int id);
    }
}
