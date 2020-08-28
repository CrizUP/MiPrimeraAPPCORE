using MiPrimeraAPPCORE.Infraestructure;
using MiPrimeraAPPCORE.Model;
using MiPrimeraAPPCORE.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Repository
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly CatalogoDbContext _bdCatalogo;

        public CategoriaRepository(CatalogoDbContext bdCatalogo)
        {
            _bdCatalogo = bdCatalogo;
        }

        public int CreateCategoria(Categoria DatosCategoria)
        {
            _bdCatalogo.Categoria.Add(DatosCategoria);
            _bdCatalogo.SaveChanges();
            return DatosCategoria.IdCategoria;
        }
        public ICollection<int> CreateCategoria(ICollection<Categoria> DatosCategoria)
        {
            _bdCatalogo.Categoria.AddRange(DatosCategoria);

            _bdCatalogo.SaveChanges();
            return DatosCategoria.Select(i => i.IdCategoria).ToList();
        }

        public bool ExisteCategoria(string Nombre)
        {
            return _bdCatalogo.Categoria.Any(x => x.Nombre == Nombre);
        }

        public Categoria GetCategoria (int Id)
        {
            var itemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == Id).FirstOrDefault();
            return itemCategoria;
        }
        public ICollection<Categoria> GetCategoria()
        {
            var itemCategoria = _bdCatalogo.Categoria.Where(x => x.Activo == true).ToList();
            return itemCategoria;
        }

        public bool DeleteCategoria(int Id)
        {
            var itemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == Id).FirstOrDefault();
            _bdCatalogo.Categoria.Remove(itemCategoria);
            _bdCatalogo.SaveChanges();
            return true;
        }

        public Categoria UpdateCategoria(Categoria DatosCategoria)
        {
            var itemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == DatosCategoria.IdCategoria).FirstOrDefault();
            itemCategoria.Nombre = DatosCategoria.Nombre;
            itemCategoria.Activo = DatosCategoria.Activo;
            _bdCatalogo.SaveChanges();
            return itemCategoria;
        }
        public ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria)
        {
            var LstItem = _bdCatalogo.Categoria.Where(x => DatosCategoria.Select(i => i.IdCategoria).ToList().Contains(x.IdCategoria)).ToList();

            LstItem.ForEach(u =>
            {
                u.Nombre = DatosCategoria.Where(i => i.IdCategoria == u.IdCategoria).Select(n => n.Nombre).FirstOrDefault();
            });
            _bdCatalogo.SaveChanges();

            return DatosCategoria;
        }

        public bool ExisteCategoria(int IdCategoria)
        {
            return _bdCatalogo.Categoria.Any(x => x.IdCategoria == IdCategoria);
        }
    }
}
