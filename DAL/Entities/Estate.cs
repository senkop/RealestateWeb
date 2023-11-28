using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Try.Models;

namespace Try.DAL.Entity
{
    [Table("Estate")]
    public class Estate
    {
     
        [Key]
        public int IdEstate { get; set; }
        public Boolean Garden { get; set; }
        public string Location { get; set; }
        public int Rooms_numbers { get; set; }
        public int Bathroom_numbers { get; set; }
        public string CompanyName { get; set; }


        public string Type { get; set; }
        public string State { get; set; }
        public Double size { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int St_num { get; set; }
        public Double Price { get; set; }
        public int Floors_numbers { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public Boolean Buy { get; set; }
        public Boolean rent { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string cover { get; set; }

        //  public string image { get; set; }



        [JsonIgnore]
        public ICollection<FavoriteEstate> FavoriteEstate { get; set; }
        //[JsonIgnore]
        //public ICollection<RecommendedEstate> RecommendedEstate { get; set; }





        //[JsonIgnore]
        //public string Hash { get; internal set; }
        //public IList<Photo> Photos
        //{
        //    get; set;

        // public string ComplnyName { get; set; }
        //[JsonIgnore]
        //public DateTime DateCreate { get; internal set; } = DateTime.Now;
        //public IList<ApartmentsImages> ApartmentsImagesa { get; set; }

        //public string UsersId { get; set; }
        //[ForeignKey(nameof(UsersId))]

        //public Users Users { get; set; }
        //public int Propertiesid { get; set; }
        //[ForeignKey("Propertiesid")]
        //public Properties Properties { get; set; }


        // public string ImageUrl { get; set; }

        //[NotMapped]
        ////[JsonIgnore]
        //public byte[] ImageArray { get; set; }


        //[JsonIgnore]
        //public virtual ICollection<Apartments> Order_Apartments { get; set; }
        //  public Estate Estate { get; set; }


        //public Apartments()
        //{
        //    Images = new HashSet<Imagex>();
        //}
    }
}
