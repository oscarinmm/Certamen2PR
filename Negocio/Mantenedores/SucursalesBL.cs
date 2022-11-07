using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class SucursalesBL : ICrud<Sucursales>
    {

        public ResponseExec Create(Sucursales o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_sucursal", o.cod_sucursal));
                o.parametros.Add(new Datos.Parametros("@nombre_suc", o.nombre_suc));
                o.parametros.Add(new Datos.Parametros("@region", o.region));
                o.parametros.Add(new Datos.Parametros("@depto", o.depto));
                o.parametros.Add(new Datos.Parametros("@jefe_suc", o.jefe_suc));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.ejecutarSP("sp_sucursales", o.parametros);
                res.mensaje = "Ingreso Correcto de Sucursal";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Sucursales o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_sucursal", o.cod_sucursal));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_SUCURSALES", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }

        }

        public Sucursales GetById(Sucursales o)
        {
            Sucursales sucursales = new Sucursales();
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_sucursal", o.cod_sucursal));
                DataTable dt = o.Data.listadoSP("SP_CARGA_CARGOS", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    sucursales.cod_sucursal = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    sucursales.nombre_suc = dt.Rows[0].ItemArray[1].ToString();
                    sucursales.region = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    sucursales.depto = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    sucursales.jefe_suc = dt.Rows[0].ItemArray[1].ToString();
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
            return sucursales;
        }

        public List<Sucursales> GetQuery(Sucursales o)
        {
            List<Sucursales> sucursales = new List<Sucursales>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@nombre_suc", o.nombre_suc));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_SUCURSALES", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sucursales;
        }


        public List<Sucursales> Get(Sucursales o)
        {
            List<Sucursales> sucursales = new List<Sucursales>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Sucursales");
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sucursales;
        }

        public ResponseExec Update(Sucursales o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_sucursal", o.cod_sucursal));
                o.parametros.Add(new Datos.Parametros("@nombre_suc", o.nombre_suc));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_SUCURSALES", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Sucursales> convertToList(DataTable dt)
        {
            List<Sucursales> listado = new List<Sucursales>();

            foreach (DataRow item in dt.Rows)
            {
                Sucursales o = new Sucursales();
                o.cod_sucursal = int.Parse(item.ItemArray[0].ToString());
                o.nombre_suc = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }

    }
}

