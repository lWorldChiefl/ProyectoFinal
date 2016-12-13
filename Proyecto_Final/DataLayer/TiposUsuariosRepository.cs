using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TiposUsuariosRepository : IRepository<Tipos_Usuarios>
    {
         Proyecto_VerocoEntities _userContext;

         public TiposUsuariosRepository()
        {
            _userContext = new Proyecto_VerocoEntities();

        }

         public IEnumerable<Tipos_Usuarios> Listar
        {
            get
            {
                return _userContext.Tipos_Usuarios;
            }

        }

         public void Crear(Tipos_Usuarios entity)
        {
            _userContext.Tipos_Usuarios.Add(entity);
            _userContext.SaveChanges();
        }

         public void Eliminar(Tipos_Usuarios entity)
        {
            _userContext.Tipos_Usuarios.Remove(entity);
            _userContext.SaveChanges();
        }

         public void Actualizar(Tipos_Usuarios entity)
        {
            _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }

         public Tipos_Usuarios Buscar(int Id)
        {
            var result = (from r in _userContext.Tipos_Usuarios where r.userTypeId == Id select r).FirstOrDefault();
            return result;
        }
    }
}
