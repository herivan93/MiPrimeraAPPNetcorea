using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.DTO
{
    public class MarcaDTO
    {
        public int ObjectId { get; set; }
        public string Nombre { get; set; }
        public Guid Logo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public Guid UsuarioCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public Guid UsuarioModifico { get; set; }
    }
}
