using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DAL.Entity
{
        [Table("Users")]
    public class Users: IdentityUser
    {
        [Key]
        public override string Id { get; set; }
        //public int Id { get; set; }
   
        //[EmailAddress]
        //public override string Email { get; set; }


        //  public DateTime Signupdate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        [JsonIgnore]    
        public virtual ICollection<FavoriteEstate> FavoriteEstates { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<RecommendedEstate> RecommendedEstates { get; set; }
        ////[JsonIgnore]
        //public virtual ICollection<FavoriteDuplexes> FavoriteDuplexes { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<FavoriteVillas> FavoriteVillas { get; set; }

        //   public virtual ICollection<Estate> Estate { get; set; }
        //public virtual ICollection<Villas> Villas { get; set; }
        //public virtual ICollection<Chalets> Chlates { get; set; }
        //public virtual ICollection<Duplex> Duplex { get; set; }
        //public virtual ICollection<Apartments> Apartments { get; set; }

        //id,fname,lname , email,password,phone,signupdate,fk(usergrouproleid)

    }
}
