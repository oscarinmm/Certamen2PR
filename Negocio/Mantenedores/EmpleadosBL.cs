using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class EmpleadosBL : ICrud<Empleados>
    {

        public ResponseExec Create(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@rut", o.rut));
                o.parametros.Add(new Datos.Parametros("@nombre", o.nombre));
                o.parametros.Add(new Datos.Parametros("@apellido", o.apellido));
                o.parametros.Add(new Datos.Parametros("@direccion", o.direccion));
                o.parametros.Add(new Datos.Parametros("@telefono", o.telefono));
                o.parametros.Add(new Datos.Parametros("@cargo", o.cargo));
                o.parametros.Add(new Datos.Parametros("@sucursal", o.sucursal));
                o.parametros.Add(new Datos.Parametros("@jefe", o.jefe));
                o.Data.ejecutarSP("sp_empleados", o.parametros);
                res.mensaje = "Ingreso Correcto de Empleado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@rut", o.rut));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_EMPLEADOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }

        }

        public Empleados GetById(Empleados o)
        {
            Empleados empleados = new Empleados();
            try
            {
                o.parametros.Add(new Datos.Parametros("@rut", o.rut));
                DataTable dt = o.Data.listadoSP("SP_CARGA_EMPLEADOS", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    empleados.rut = (dt.Rows[0].ItemArray[0].ToString());
                    empleados.nombre = dt.Rows[0].ItemArray[1].ToString();
                    empleados.apellido = (dt.Rows[0].ItemArray[0].ToString());
                    empleados.direccion = (dt.Rows[0].ItemArray[0].ToString());
                    empleados.telefono = int.Parse(dt.Rows[0].ItemArray[1].ToString());
                    empleados.cargo = (dt.Rows[0].ItemArray[0].ToString());
                    empleados.sucursal = (dt.Rows[0].ItemArray[0].ToString());
                    empleados.jefe = (dt.Rows[0].ItemArray[0].ToString());
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
            return empleados;
        }

        public List<Empleados> GetQuery(Empleados o)
        {
            List<Empleados> empleados = new List<Empleados>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@nombre", o.nombre));
                DataTable dt = o.Data.listadoSP("SP_BUSCA_EMPLEADOS", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleados;
        }


        public List<Empleados> Get(Empleados o)
        {
            List<Empleados> empleados = new List<Empleados>();
            try
            {
                DataTable dt = o.Data.queryData("select * from empleados");
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleados;
        }

        public ResponseExec Update(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@rut", o.rut));
                o.parametros.Add(new Datos.Parametros("@nombre", o.nombre));
                o.parametros.Add(new Datos.Parametros("@apellido", o.apellido));
                o.parametros.Add(new Datos.Parametros("@direccion", o.direccion));
                o.parametros.Add(new Datos.Parametros("@telefono", o.telefono));
                o.parametros.Add(new Datos.Parametros("@cargo", o.cargo));
                o.parametros.Add(new Datos.Parametros("@sucursal", o.sucursal));
                o.parametros.Add(new Datos.Parametros("@jefe", o.jefe));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_EMPLEADOS", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Empleados> convertToList(DataTable dt)
        {
            List<Empleados> listado = new List<Empleados>();

            foreach (DataRow item in dt.Rows)
            {
                Empleados o = new Empleados();
                o.rut = (item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }

    }
}

