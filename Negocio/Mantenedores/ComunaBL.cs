using System;
using System.Data;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class ComunaBL:ICrud<Comuna>
    {
        public ComunaBL()
        {
        }

        public ResponseExec Create(Comuna o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_INGRESAR_COMUNA", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Comuna o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_COMUNA", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Comuna> Get(Comuna o)
        {
            List<Comuna> comunas = new List<Comuna>();
            try
            {
                DataTable dt = o.Data.listadoSP("SP_LISTAR_COMUNA", null);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comunas;
        }

        public Comuna GetById(Comuna o)
        {
            Comuna comuna = new Comuna();
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                DataTable dt = o.Data.listadoSP("SP_CARGA_COMUNA", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    comuna.codigo = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    comuna.nombre = dt.Rows[0].ItemArray[1].ToString();
                    return comuna;
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
            return comuna;
        }

        public List<Comuna> GetQuery(Comuna o)
        {
            List<Comuna> comuna = new List<Comuna>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_COMUNA", o.parametros);
                comuna = convertToList(dt);
                return comuna;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comuna;
        }

        public ResponseExec Update(Comuna o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_COMUNA", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }
        public List<Comuna> convertToList(DataTable dt)
        {
            List<Comuna> listado = new List<Comuna>();

            foreach (DataRow item in dt.Rows)
            {
                Comuna o = new Comuna();
                o.codigo = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}

