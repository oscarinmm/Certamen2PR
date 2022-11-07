using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class CargoBL : ICrud<Cargo>
    {

        public ResponseExec Create(Cargo o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.ejecutarSP("sp_cargos", o.parametros);
                res.mensaje = "Ingreso Correcto del Cargo";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Cargo o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_CARGOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }

        }

        public Cargo GetById(Cargo o)
        {
            Cargo cargo = new Cargo();
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                DataTable dt = o.Data.listadoSP("SP_CARGA_CARGOS", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    cargo.codigo = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    cargo.nombre = dt.Rows[0].ItemArray[1].ToString();
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cargo;
        }

        public List<Cargo> GetQuery(Cargo o)
        {
            List<Cargo> cargos = new List<Cargo>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_CARGOS", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cargos;
        }


        public List<Cargo> Get(Cargo o)
        {
            List<Cargo> cargos = new List<Cargo>();
            try
            {
                DataTable dt = o.Data.queryData("select * from cargos");
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cargos;
        }

        public ResponseExec Update(Cargo o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_CARGOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Cargo> convertToList(DataTable dt)
        {
            List<Cargo> listado = new List<Cargo>();

            foreach (DataRow item in dt.Rows)
            {
                Cargo o = new Cargo();
                o.codigo = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }

    }
}

