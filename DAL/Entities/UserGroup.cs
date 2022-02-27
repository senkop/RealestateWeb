using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("Usergroup")]
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        //id,role , desc
    }
}
