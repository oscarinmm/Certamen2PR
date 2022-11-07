using System;
using Datos;

namespace Modelos.Mantenedores
{
    public class Cargo : IDataEntity
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Cargo()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}

