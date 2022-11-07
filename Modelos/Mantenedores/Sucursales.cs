using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedores
{

    public class Sucursales : IDataEntity
    {
        public int cod_sucursal { get; set; }
        public string nombre_suc { get; set; }
        public int region { get; set; }
        public int depto { get; set; }
        public string jefe_suc { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Sucursales()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }

}
