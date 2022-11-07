using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedores
{

    public class Departamento : IDataEntity
    {
        public int cod_depto { get; set; }
        public string nombre_depto { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public Departamento()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }

}
