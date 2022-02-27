using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DAL.Entity
{
    [Table("Order_Estate")]
    public class Order_Estate
    {
        [Key]
        public int Id { get; set; }
        public int Orderid { get; set; }
        [ForeignKey("Orderid")]
        public Orders Orders { get; set; }
        public int Estateid { get; set; }
        [ForeignKey("Estateid")]
        public Estate Estate { get; set; }
    }
}
