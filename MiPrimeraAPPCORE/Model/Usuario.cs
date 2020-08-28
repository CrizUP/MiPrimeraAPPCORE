using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Model
{
    [Table("Usuario", Schema = "Cat")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public byte[] HashPassword { get; set; }
        [Required]
        public byte[] SaltPass { get; set; }
        //[Required]
        //public bool Activo { get; set; }
        //[Required]
        //public DateTime FechaCreo { get; set; }
        //public DateTime FechaModifico { get; set; }
    }
}
