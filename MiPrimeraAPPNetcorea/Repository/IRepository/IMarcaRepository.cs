using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Repository.IRepository
{
    public interface IMarcaRepository
    {
        ICollection<Marca> GetMarca();
        Marca GetMarca(int IdMarca);
        bool ExistsMarca(string Nombre);
        bool ExistsMarca(int IdMarca);
        Guid CreateMarca(Marca DatosMarca);
        ICollection<int> CreateMarca(ICollection<Marca> DatosMarca);
        bool DeleteMarca(Guid IdMarca);
        bool DeleteMarca(ICollection<int> IdMarca);
        Marca UpdateMarca(Marca DatosMarca);
        ICollection<Marca> UpdateMarca(ICollection<Marca> DatosMarca);
    }
}
