using System;
using Datos;

namespace Modelos
{
    public interface IDataEntity
    {
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
    }
}
