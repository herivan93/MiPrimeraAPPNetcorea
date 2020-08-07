using MiPrimeraAPPNetcorea.Infraestructure;
using MiPrimeraAPPNetcorea.Model;
using MiPrimeraAPPNetcorea.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly CatalogoDbContext _bdCatalogo;

        public MarcaRepository(CatalogoDbContext bdCatalogo)
        {
            _bdCatalogo = bdCatalogo;

        }
        public int CreateMarca(Marca DatosMarca)
        {
            _bdCatalogo.Marca.Add(DatosMarca);
            _bdCatalogo.SaveChanges();
            return DatosMarca.ObjectId;
           
        }

        public ICollection<int> CreateMarca(ICollection<Marca> DatoMarca)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMarca(int MarcaObjectId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMarca(ICollection<int> MarcaObjectId)
        {
            throw new NotImplementedException();
        }

        public bool ExistsMarca(string Nombre)
        {
            throw new NotImplementedException();
        }

        public bool ExistsMarca(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Marca> GetMarca()
        {
            throw new NotImplementedException();
        }

        public Marca GetMarca(int Id)
        {
            throw new NotImplementedException();
        }

        public Marca UpdateMarca(Marca DatoMarca)
        {
            throw new NotImplementedException();
        }

        public ICollection<Marca> UpdateMarca(ICollection<Marca> DatoMarca)
        {
            throw new NotImplementedException();
        }
    }
}
