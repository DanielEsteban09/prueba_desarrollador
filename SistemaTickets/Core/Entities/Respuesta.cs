using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Respuesta
    {
        public string mensaje {  get; set; }

        [Key]
        public decimal identificador { get; set; }
        public string estado { get; set; }
    }
}
