using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.DTO
{
    public class UsuarioDTO
    {
        public string ClientId { get; set; }
        public byte[] HashPassword { get; set; }
    }
}
