using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("RecommendedEstate")]
    public class RecommendedEstate
    {
        [Key]
        public int RecommendedEstateId { get; set; }
        public string UsersId { get; set; }
        [ForeignKey(nameof(UsersId))]

        [JsonIgnore]
        public Users Users { get; set; }

        public int EstateId { get; set; }
        [ForeignKey(nameof(EstateId))]

        [JsonIgnore]
        public Estate Estate { get; set; }




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
