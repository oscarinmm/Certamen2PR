using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedores
{

    public class Regiones : IDataEntity
    {
        public int id_region { get; set; }
        public string nombre_region { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Regiones()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }

  
}
