using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedores
{

    public class Empleados : IDataEntity
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string cargo { get; set; }
        public string sucursal { get; set; }
        public string jefe { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Empleados()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }

}
