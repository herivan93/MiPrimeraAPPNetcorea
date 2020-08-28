using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Model
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string ClientId { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPass { get; set; }
    }
}
