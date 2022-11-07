using Modelos.Mantenedores;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Mantenedores
{
    public class RegionesBL : ICrud<Regiones>
    {

        public ResponseExec Create(Regiones o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@id_region", o.id_region));
                o.parametros.Add(new Datos.Parametros("@nombre_region", o.nombre_region));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.ejecutarSP("sp_regiones", o.parametros);
                res.mensaje = "Ingreso Correcto de la region";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Regiones o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@id_region", o.id_region));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_REGION", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }

        }

        public Regiones GetById(Regiones o)
        {
            Regiones regiones = new Regiones();
            try
            {
                o.parametros.Add(new Datos.Parametros("@id_region", o.id_region));
                DataTable dt = o.Data.listadoSP("SP_CARGA_REGIONES", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    regiones.id_region = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    regiones.nombre_region = dt.Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return regiones;
        }

        public List<Regiones> GetQuery(Regiones o)
        {
            List<Regiones> regiones = new List<Regiones>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@nombre_region", o.nombre_region));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_REGIONES", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return regiones;
        }


        public List<Regiones> Get(Regiones o)
        {
            List<Regiones> regiones = new List<Regiones>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Regiones");
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return regiones;
        }

        public ResponseExec Update(Regiones o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@id_region", o.id_region));
                o.parametros.Add(new Datos.Parametros("@nombre_region", o.nombre_region));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_REGIONES", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Regiones> convertToList(DataTable dt)
        {
            List<Regiones> listado = new List<Regiones>();

            foreach (DataRow item in dt.Rows)
            {
                Regiones o = new Regiones();
                o.id_region = int.Parse(item.ItemArray[0].ToString());
                o.nombre_region = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }

    }
}
