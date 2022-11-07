using System;
using Datos;

namespace Modelos.Mantenedores
{
    public class Colegio : IDataEntity
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string codigotipo { get; set; }
        public string comuna { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string director { get; set; }
        public bool sector { get; set; }
        public int movilizacion { get; set; }
        public string texto { get; set; }
        public int colacion { get; set; }
        public string jornada { get; set; }
        public int pme { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Colegio()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}

