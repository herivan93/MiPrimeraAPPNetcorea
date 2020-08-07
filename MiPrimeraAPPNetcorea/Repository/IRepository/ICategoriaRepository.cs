using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        int CreateCategoria(Categoria DatosCategoria);
        ICollection<int> CreateCategoria(ICollection<Categoria> DatosCategoria);
        bool ExisteCategoria(string Nombre);
        Categoria GetCategoria(int Id);
        bool DeleteCategoria(int Id);
        Categoria UpdateCategoria(Categoria DatosCategoria);
        ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria);
    }
}
