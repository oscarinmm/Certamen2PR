using System;
using Datos;
using System.Data;
using Modelos;
using Modelos.Mantenedores;
using System.Collections.Generic;
using System.IO;

namespace Negocio.Mantenedores
{
    public class ColegioBL:ICrud<Colegio>
    {
        public ColegioBL()
        {
        }

        public ResponseExec Create(Colegio o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                o.parametros.Add(new Datos.Parametros("@CODIGOTIPO", o.codigotipo));
                o.parametros.Add(new Datos.Parametros("@CODIGOCOMUNA", o.comuna));
                o.parametros.Add(new Datos.Parametros("@DIRECCION", o.direccion));
                o.parametros.Add(new Datos.Parametros("@TELEFONO", o.telefono));
                o.parametros.Add(new Datos.Parametros("@DIRECTOR", o.director));
                o.parametros.Add(new Datos.Parametros("@SECTOR", o.sector));
                o.parametros.Add(new Datos.Parametros("@MOVILIZACION", o.movilizacion));
                o.parametros.Add(new Datos.Parametros("@TEXTO", o.texto));
                o.parametros.Add(new Datos.Parametros("@COLACION", o.colacion));
                o.parametros.Add(new Datos.Parametros("@PME", o.pme));
                o.parametros.Add(new Datos.Parametros("@JORNADA", o.jornada));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_INGRESAR_COLEGIO", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Colegio o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ELIMINAR_COLEGIO", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Colegio> Get(Colegio o)
        {
            List<Colegio> colegios = new List<Colegio>();
            try
            {
                DataTable dt = o.Data.listadoSP("SP_LISTAR_COLEGIO", null);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return colegios;
        }

        public Colegio GetById(Colegio o)
        {
            Colegio colegio = new Colegio();
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                DataTable dt = o.Data.listadoSP("SP_CARGAR_COLEGIO", o.parametros);
                if (dt.Rows.Count > 0)
                {
                    return convertToList(dt).FirstOrDefault();
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
            return colegio;
        }

        public List<Colegio> GetQuery(Colegio o)
        {
            List<Colegio> colegios = new List<Colegio>();
            try
            {
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                DataTable dt = o.Data.listadoSP("SP_BUSCAR_COLEGIO", o.parametros);
                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return colegios;
        }

        public ResponseExec Update(Colegio o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                o.parametros.Add(new Datos.Parametros("@NOMBRE", o.nombre));
                o.parametros.Add(new Datos.Parametros("@CODIGOTIPO", o.codigotipo));
                o.parametros.Add(new Datos.Parametros("@CODIGOCOMUNA", o.comuna));
                o.parametros.Add(new Datos.Parametros("@DIRECCION", o.direccion));
                o.parametros.Add(new Datos.Parametros("@TELEFONO", o.telefono));
                o.parametros.Add(new Datos.Parametros("@DIRECTOR", o.director));
                o.parametros.Add(new Datos.Parametros("@SECTOR", o.sector));
                o.parametros.Add(new Datos.Parametros("@MOVILIZACION", o.movilizacion));
                o.parametros.Add(new Datos.Parametros("@TEXTO", o.texto));
                o.parametros.Add(new Datos.Parametros("@COLACION", o.colacion));
                o.parametros.Add(new Datos.Parametros("@PME", o.pme));
                o.parametros.Add(new Datos.Parametros("@JORNADA", o.jornada));
                o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                res.mensaje = o.Data.ejecutarSP("SP_ACTUALIZAR_COLEGIO", o.parametros);
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }
        public List<Colegio> convertToList(DataTable dt)
        {
            List<Colegio> listado = new List<Colegio>();

            foreach (DataRow item in dt.Rows)
            {
                Colegio o = new Colegio();
                o.codigo = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.codigotipo = item.ItemArray[2].ToString();
                o.comuna = item.ItemArray[3].ToString();
                o.direccion = item.ItemArray[4].ToString();
                o.telefono = item.ItemArray[5].ToString();
                o.director = item.ItemArray[6].ToString();
                o.sector = item.ItemArray[7].ToString() == "True" ? true : false;
                o.movilizacion = int.Parse(item.ItemArray[8].ToString());
                o.texto = item.ItemArray[9].ToString();
                o.colacion = int.Parse(item.ItemArray[10].ToString());
                o.pme = int.Parse(item.ItemArray[11].ToString());
                o.jornada = item.ItemArray[12].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}

