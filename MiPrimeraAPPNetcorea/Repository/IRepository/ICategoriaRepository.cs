using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategoria();
        Categoria GetCategoria(int IdCategoria);
        bool ExistsCategoria(string Nombre);
        bool ExistsCategoria(int IdCategoria);
        int CreateCategoria(Categoria DatosCategoria);
        bool DeleteCategoria(int IdCategoria);
        bool DeleteCategoria(ICollection<int> IdCategoria);
        Categoria UpdateCategoria(Categoria DatosCategoria);
        ICollection<Categoria> UpdateCategoria(ICollection<Categoria> DatosCategoria);
    }
}
