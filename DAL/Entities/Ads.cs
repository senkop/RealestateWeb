using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("Ads")]
    public class Ads
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength]

        public string Description { get; set; }
        public int Usersid { get; set; }
        [ForeignKey("Usersid")]
        public Users Users { get; set; }
    }
}
