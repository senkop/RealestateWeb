    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Try.Models
{
    public class EmailResponse
    {
        public bool Enviado { get; set; }
        public ErrorResponse error { get; set; }

    }
}
