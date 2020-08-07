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
        Marca GetMarca(int Id);
        bool ExistsMarca(string Nombre);
        bool ExistsMarca(int Id);
        int CreateMarca(Marca DatosMarca);
        ICollection<int> CreateMarca(ICollection<Marca> DatoMarca);
        bool DeleteMarca(int MarcaObjectId);
        bool DeleteMarca(ICollection<int> MarcaObjectId);
        Marca UpdateMarca(Marca DatoMarca);
        ICollection<Marca> UpdateMarca(ICollection<Marca> DatoMarca);

    }
}
