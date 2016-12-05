using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Listar { get; }
        void Crear(T entity);
        void Eliminar(T entity);
        void Actualizar(T entity);
        T Buscar(int Id);
    }

    public class UsuariosRepository : IRepository<Usuario>
    {

        Proyecto_VerocoEntities _userContext;

        public UsuariosRepository()
        {
            _userContext = new Proyecto_VerocoEntities();

        }
        public IEnumerable<Usuario> Listar
        {
            get
            {
                return _userContext.Usuarios;
            }

        }

        public void Crear(Usuario entity)
        {
            _userContext.Usuarios.Add(entity);
            _userContext.SaveChanges();
        }

        public void Eliminar(Usuario entity)
        {
            _userContext.Usuarios.Remove(entity);
            _userContext.SaveChanges();
        }

        public void Actualizar(Usuario entity)
        {
            _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();

        }

        public Usuario Buscar(int Id)
        {
            var result = (from r in _userContext.Usuarios where r.userId == Id select r).FirstOrDefault();
            return result;
        }

    }


}
