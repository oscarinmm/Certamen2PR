using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class DeptosBL : ICrud<Departamento>
    {

        public ResponseExec Create(Departamento o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_depto", o.cod_depto));
                o.parametros.Add(new Datos.Parametros("@nombre_depto", o.nombre_depto));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.ejecutarSP("sp_deptos", o.parametros);
                res.mensaje = "Ingreso Correcto del Departamento";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Departamento o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_depto", o.cod_depto));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_DEPTOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }

        }

        public Departamento GetById(Departamento o)
        {
            Departamento departamento = new Departamento();
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_depto", o.cod_depto));
                DataTable dt = o.Data.listadoSP("SP_CARGA_DEPARTAMENTOS", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    departamento.cod_depto = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    departamento.nombre_depto = dt.Rows[0].ItemArray[1].ToString();
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamento;
        }

        public List<Departamento> GetQuery(Departamento o)
        {
            List<Departamento> departamento = new List<Departamento>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@nombre_depto", o.nombre_depto));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_DEPTOS", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamento;
        }


        public List<Departamento> Get(Departamento o)
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Deptos");
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamentos;
        }

        public ResponseExec Update(Departamento o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@cod_depto", o.cod_depto));
                o.parametros.Add(new Datos.Parametros("@nombre_depto", o.nombre_depto));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_DEPARTAMENTOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Departamento> convertToList(DataTable dt)
        {
            List<Departamento> listado = new List<Departamento>();

            foreach (DataRow item in dt.Rows)
            {
                Departamento o = new Departamento();
                o.cod_depto = int.Parse(item.ItemArray[0].ToString());
                o.nombre_depto = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }

    }
}

