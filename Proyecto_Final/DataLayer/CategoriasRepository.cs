using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoriasRepository : IRepository<Categoria>
    {
        Proyecto_VerocoEntities _userContext;

        public CategoriasRepository()
        {
            _userContext = new Proyecto_VerocoEntities();

        }

        public IEnumerable<Categoria> Listar
        {
            get
            {
                return _userContext.Categorias;
            }

        }

        public void Crear(Categoria entity)
        {
            _userContext.Categorias.Add(entity);
            _userContext.SaveChanges();
        }

        public void Eliminar(Categoria entity)
        {
            _userContext.Categorias.Remove(entity);
            _userContext.SaveChanges();
        }

        public void Actualizar(Categoria entity)
        {
            _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }

        public Categoria Buscar(int Id)
        {
            var result = (from r in _userContext.Categorias where r.categoryId == Id select r).FirstOrDefault();
            return result;
        }
    }
}
