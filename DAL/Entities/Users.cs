using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DAL.Entity
{
        [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Fname { get; set; }
        [StringLength(50)]
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime Signupdate { get; set; }

        public int Usergroupid { get; set; }
        [ForeignKey("Usergroupid")]
        public UserGroup Usergroup { get; set; }
        public virtual ICollection<Estate> Estate { get; set; }
        //id,fname,lname , email,password,phone,signupdate,fk(usergrouproleid)

    }
}
