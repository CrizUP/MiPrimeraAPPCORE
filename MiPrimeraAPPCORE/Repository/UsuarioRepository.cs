using MiPrimeraAPPCORE.Infraestructure;
using MiPrimeraAPPCORE.Model;
using MiPrimeraAPPCORE.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CatalogoDbContext _bdCatalogo;

        public UsuarioRepository(CatalogoDbContext bdCatalogo)
        {
            _bdCatalogo = bdCatalogo;
        }

        public bool ExisteUsuario(string UsuarioClientId)
        {
            return _bdCatalogo.Usuario.Any(x => x.ClientId == UsuarioClientId);
        }

        public Usuario GetUsuario(int IdUsuario)
        {
            var item = _bdCatalogo.Usuario.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
            return item;
        }

        public ICollection<Usuario> GetUsuarios()
        {
            var lstUsuarios = _bdCatalogo.Usuario.ToList();
            return lstUsuarios;
        }

        public Usuario Login(string Usuario, string Password)
        {
            var usuarioCredencial = _bdCatalogo.Usuario.Where(x => x.ClientId == Usuario).FirstOrDefault();
            if (usuarioCredencial == null)
            {
                return null;
            }

            if (!Criptography.ValidacionPassword(Password, usuarioCredencial.HashPassword, usuarioCredencial.SaltPass))
            {
                return null;
            }
            return usuarioCredencial;
        }

        public int Registrar(Usuario Usuario, string Password)
        {
            byte[] HashPassword, SaltPassword;

            Criptography.CrearPasswordEnCriptado(Password, out HashPassword, out SaltPassword);

            Usuario.HashPassword = HashPassword;
            Usuario.SaltPass = SaltPassword;

            _bdCatalogo.Usuario.Add(Usuario);
            _bdCatalogo.SaveChanges();

            return Usuario.IdUsuario;
        }
    }
}
