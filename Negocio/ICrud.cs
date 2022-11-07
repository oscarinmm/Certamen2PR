using System;
using Modelos;
namespace Negocio
{
    public interface ICrud<T> where T : IDataEntity
    {
        
        public ResponseExec Create(T o);
        public T GetById(T o);
        public List<T> GetQuery(T o);
        public List<T> Get(T o);
        public ResponseExec Update(T o);
        public ResponseExec Delete(T o);
    }
}

