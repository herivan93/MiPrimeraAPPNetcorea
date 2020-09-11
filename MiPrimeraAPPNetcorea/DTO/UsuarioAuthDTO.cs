using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.DTO
{
    public class UsuarioAuthDTO
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "EL nombre usuario Correo o Guid es necesario")]
        public string ClientId { get; set; }
        [Required(ErrorMessage = "La contresena es requerida")]
        [StringLength(12,MinimumLength =6, ErrorMessage ="Logitud no valida debe ser entre 6 y 12")]
        public string Password { get; set; }
    }
}
