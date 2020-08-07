using MiPrimeraAPPNetcorea.Infraestructure;
using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Repository
{
    public class CategoriaRepository
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
            return DatosCategoria.Select(i=> i.IdCategoria).ToList();
        }

        public bool ExisteCategoria(string Nombre)
        {
            return _bdCatalogo.Categoria.Any(x => x.Nombre == Nombre);
        }

        public Categoria GetCategoria(int Id)
        {
            var ItemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == Id).FirstOrDefault();

            return ItemCategoria;
        }

        public bool DeleteCategoria(int Id)
        {

            var ItemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == Id).FirstOrDefault();

            _bdCatalogo.Categoria.Remove(ItemCategoria);
            _bdCatalogo.SaveChanges();

            return true;

        }

        public Categoria UpdateCategoria(Categoria DatosCategoria)
        {
            var ItemCategoria = _bdCatalogo.Categoria.Where(x => x.IdCategoria == DatosCategoria.IdCategoria).FirstOrDefault();
            ItemCategoria.Nombre = DatosCategoria.Nombre;
            _bdCatalogo.SaveChanges();
            return ItemCategoria;
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

    }
}
