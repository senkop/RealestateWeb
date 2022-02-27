using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DAL.Entity
{
    [Table("Estate")]
    public class Estate
    {
        [Key]
        public int Id { get; set; }
        public  string Image { get; set; }
        [MaxLength]
        public string Location { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int St_num { get; set; }
        public Double Price { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public string Filter { get; set; }
        public int Usersid { get; set; }
        [ForeignKey("Usersid")]

        public Users Users { get; set; }
        public int Propertiesid { get; set; }
        [ForeignKey("Propertiesid")]
        public Properties Properties { get; set; }
        public virtual ICollection<Estate> Order_estate { get; set; }
        //product :id,photo,location(state,city,street,num),price,desc,filter,fk(userid),fk(propertiesid)
    }
}
