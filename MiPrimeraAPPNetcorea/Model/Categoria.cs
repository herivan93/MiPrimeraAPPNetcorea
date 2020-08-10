using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiPrimeraAPPNetcorea.Model
{
    [Table("Categoria",Schema = "Cat" )]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public Guid ImagenMiniatura { get; set; }
        public Guid ImagenBanner { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        [Required]
        public Guid UsuarioCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public Guid UsuarioModifico { get; set; }

    }
}
