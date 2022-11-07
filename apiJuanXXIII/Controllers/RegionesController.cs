using System;
using System.Reflection;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace apiJuanXXIII.Controllers
{
    [ApiController]
    public class RegionesController : ControllerBase
    {
            RegionesBL regionesBL = new RegionesBL();
            Regiones regiones = new Regiones();
            ErrorResponse error;

            [HttpPost]
            [Route("v1/regiones/Create")]
            public ActionResult Create(RegionesDTO o)
            {
                try
                {
                    regiones.id_region = o.Id_region;
                    regiones.nombre_region = o.Nombre_region;
                    return Ok(regionesBL.Create(regiones));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/regiones/Get")]
            public ActionResult Get()
            {
                try
                {
                    return Ok(convertList(regionesBL.Get(regiones)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpPost]
            [Route("v1/regiones/GetQuery")]
            public ActionResult GetQuery(string nombre)
            {
                try
                {
                    regiones.nombre_region = nombre;
                    return Ok(convertList(regionesBL.GetQuery(regiones)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/regiones/GetById")]
            public ActionResult GetById(int id)
            {
                try
                {
                    regiones.id_region = id;
                    regiones = regionesBL.GetById(regiones);
                    if (regiones!= null)
                        return Ok(convert(regiones));
                    else
                    return StatusCode(404, regiones);
            }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }
            [HttpPut]
            [Route("v1/regiones/Update")]
            public ActionResult Update(RegionesDTO o)
            {
                try
                {
                    regiones.id_region = o.Id_region;
                    regiones.nombre_region = o.Nombre_region;
                    return Ok(regionesBL.Update(regiones));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpDelete]
            [Route("v1/regiones/Delete")]
            public ActionResult Delete(int codigo)
            {
                try
                {
                    regiones.id_region = codigo;
                    return Ok(regionesBL.Delete(regiones));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            private List<RegionesDTO> convertList(List<Regiones> lista)
            {
                List<RegionesDTO> list = new List<RegionesDTO>();
                foreach (var item in lista)
                {
                    RegionesDTO el = new RegionesDTO(item.id_region,item.nombre_region);
                    list.Add(el);
                    
                }
                return list;

            }
            private RegionesDTO convert(Regiones item)
            {
                RegionesDTO obj= new RegionesDTO(item.id_region,item.nombre_region);
                return obj;

            }
    }
    }
