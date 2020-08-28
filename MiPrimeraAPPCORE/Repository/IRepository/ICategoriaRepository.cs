using MiPrimeraAPPCORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        int CreateCategoria(Categoria DatosCategoria);
        ICollection<int> CreateCategoria(ICollection<Categoria> DatosCategoria);
        bool ExisteCategoria(string Nombre);
        bool ExisteCategoria(int IdCategoria);
        Categoria GetCategoria(int Id);
         ICollection<Categoria> GetCategoria();
        bool DeleteCategoria(int Id);
        Categoria UpdateCategoria(Categoria DatosCategoria);
        ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria);
    }
}
