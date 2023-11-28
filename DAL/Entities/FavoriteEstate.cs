using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("FavoriteEstate")]
    public class FavoriteEstate
    {
        [Key]
        public int FavoriteId { get; set; }
        //public string UsersId { get; set; }
        //[ForeignKey(nameof(UsersId))]

        //[JsonIgnore]
        //public Users Users { get; set; }

        public string UsersId { get; set; }
        [ForeignKey(nameof(UsersId))]

        [JsonIgnore]
        public Users Users { get; set; }

        public int EstateId { get; set; }
        [ForeignKey(nameof(EstateId))]

        [JsonIgnore]
        public Estate Estates { get; set; }


        //public Boolean Garden { get; set; }
     //   public string Location { get; set; }
        //public string Rooms_numbers { get; set; }
        //public string Bathroom_numbers { get; set; }
        //public string CompanyName { get; set; }


        //public string Type { get; set; }
        //public string State { get; set; }
        //public Double size { get; set; }
        //public string City { get; set; }
        //public string Street { get; set; }
        //public int St_num { get; set; }
        //public Double Price { get; set; }
        //public int Floors_numbers { get; set; }
        //[MaxLength]
        //public string Description { get; set; }
        //public Boolean Buy { get; set; }
        //public Boolean rent { get; set; }
        //public string image1 { get; set; }
        //public string image2 { get; set; }
        //public string image3 { get; set; }
        //public string cover { get; set; }



        //public DateTime DateCreated { get; set; }
        //public cart()
        //{
        //    CartItems = new List<CartItem>();
        //}

        //public List<CartItem> CartItems { get; set; }
        //[Key]
        //public int Id { get; set; }
        //public string Status { get; set; }

        //public string UsersId { get; set; }
        //[ForeignKey(nameof(UsersId))]

        //[JsonIgnore]
        //public Users Users { get; set; }
        //public string ApartmentId { get; set; }
        //[ForeignKey(nameof(ApartmentId))]

        //[JsonIgnore]
        //public Apartments Apartments { get; set; }



        //    public virtual ICollection<Client_orders> Client_Orders { get; set; }

        //  [JsonIgnore]
        //public virtual ICollection<Orders_Apartments> Orders_Apartments { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Orders_Chalets> Orders_Chalets { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Orders_Duplex> Orders_Duplex { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Orders_Villas> Orders_Villas { get; set; }
    }
}
