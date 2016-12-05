using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class IEntity
    {
        public string Id;
    }

    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> Listar { get; }
        void Crear(T entity);
        void Eliminar(T entity);
        void Actualizar(T entity);
        T FindById(int Id);
    }



}
