using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Try.DAL.Entity
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Problem { get; set; }
        public  string Solution { get; set; }
        public DateTime Date { get; set; }
        public int Clientsid { get; set; }
        [ForeignKey("Clientsid")]
        public Clients Clients { get; set; }

        //:id,number,problem,solution,date,fk(clientid)

    }
}
