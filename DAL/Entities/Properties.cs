using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Try.DAL.Entity
{
    [Table("Properties")]
    public class Properties
    {
        
        [Key]
        public int Id { get; set; }

        public int Num_rooms{ get; set; }
        public int Num_bathrooms { get; set; }
        public string Size { get; set; }
        [MaxLength]
        public string Description { get; set; }
        
        public string Images { get; set; }

        public virtual ICollection<Estate> Estate { get; set; }
        //properties:id,num_rooms,size,bathroom_num,Desc,photos
    }
}
