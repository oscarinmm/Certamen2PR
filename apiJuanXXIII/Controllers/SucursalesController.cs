using System;
using System.Reflection;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace apiJuanXXIII.Controllers
{
    [ApiController]
    public class SucursalesController : ControllerBase
    {
            SucursalesBL sucursalesBL = new SucursalesBL();
            Sucursales sucursales = new Sucursales();
            ErrorResponse error;

            [HttpPost]
            [Route("v1/sucursales/Create")]
            public ActionResult Create(SucursalesDTO o)
            {
                try
                {
                    sucursales.cod_sucursal = o.cod_sucursal;
                    sucursales.nombre_suc = o.nombre_suc;
                    sucursales.region = o.region;
                    sucursales.depto = o.depto;
                    sucursales.jefe_suc = o.jefe_suc;
                return Ok(sucursalesBL.Create(sucursales));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/sucursales/Get")]
            public ActionResult Get()
            {
                try
                {
                    return Ok(convertList(sucursalesBL.Get(sucursales)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpPost]
            [Route("v1/sucursales/GetQuery")]
            public ActionResult GetQuery(string nombre_suc)
            {
                try
                {
                    sucursales.nombre_suc = nombre_suc;
                    return Ok(convertList(sucursalesBL.GetQuery(sucursales)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/sucursales/GetById")]
            public ActionResult GetById(int cod_sucursal)
            {
                try
                {
                    sucursales.cod_sucursal = cod_sucursal;
                    sucursales = sucursalesBL.GetById(sucursales);
                    if (sucursales!= null)
                        return Ok(convert(sucursales));
                    else
                    return StatusCode(404, sucursales);
            }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }
            [HttpPut]
            [Route("v1/sucursales/Update")]
            public ActionResult Update(SucursalesDTO o)
            {
                try
                {
                    sucursales.cod_sucursal = o.cod_sucursal;
                    sucursales.nombre_suc = o.nombre_suc;
                    return Ok(sucursalesBL.Update(sucursales));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpDelete]
            [Route("v1/sucursales/Delete")]
            public ActionResult Delete(int cod_sucursal)
            {
                try
                {
                    sucursales.cod_sucursal = cod_sucursal;
                    return Ok(sucursalesBL.Delete(sucursales));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            private List<SucursalesDTO> convertList(List<Sucursales> lista)
            {
                List<SucursalesDTO> list = new List<SucursalesDTO>();
                foreach (var item in lista)
                {
                    SucursalesDTO el = new SucursalesDTO(item.cod_sucursal,item.nombre_suc,item.region,item.depto,item.jefe_suc);
                    list.Add(el);
                    
                }
                return list;

            }
            private SucursalesDTO convert(Sucursales item)
            {
                SucursalesDTO obj= new SucursalesDTO(item.cod_sucursal, item.nombre_suc, item.region, item.depto, item.jefe_suc);
                return obj;

            }
    }
    }
