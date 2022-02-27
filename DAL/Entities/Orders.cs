using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Client_orders> Client_Orders { get; set; }
        public virtual ICollection<Order_Estate> Order_estate { get; set; }
    }
}
