using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DAL.Entity
{
    [Table("Interests")]
    public class Interests
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Client_interesets> Client_Interesets { get; set; }
    }
}
