using System;
using System.Reflection;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace apiJuanXXIII.Controllers
{
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
            EmpleadosBL empleadosBL = new EmpleadosBL();
            Empleados empleados = new Empleados();
            ErrorResponse error;

            [HttpPost]
            [Route("v1/empleados/Create")]
            public ActionResult Create(EmpleadosDTO o)
            {
                try
                {
                    empleados.rut = o.rut;
                    empleados.nombre = o.nombre;
                    empleados.apellido = o.apellido;
                    empleados.direccion = o.direccion;
                    empleados.telefono = o.telefono;
                    empleados.cargo = o.cargo;
                    empleados.sucursal = o.sucursal;
                    empleados.jefe = o.jefe;
                return Ok(empleadosBL.Create(empleados));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/empleados/Get")]
            public ActionResult Get()
            {
                try
                {
                    return Ok(convertList(empleadosBL.Get(empleados)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpPost]
            [Route("v1/empleados/GetQuery")]
            public ActionResult GetQuery(string nombre)
            {
                try
                {
                    empleados.nombre = nombre;
                    return Ok(convertList(empleadosBL.GetQuery(empleados)));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpGet]
            [Route("v1/empleados/GetById")]
            public ActionResult GetById(string rut)
            {
                try
                {
                    empleados.rut = rut;
                    empleados = empleadosBL.GetById(empleados);
                    if (empleados != null)
                        return Ok(convert(empleados));
                    else
                    return StatusCode(404, empleados);
            }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }
            [HttpPut]
            [Route("v1/empleados/Update")]
            public ActionResult Update(EmpleadosDTO o)
            {
                try
                {
                    empleados.rut = o.rut;
                    empleados.nombre = o.nombre;
                    empleados.apellido = o.apellido;
                    empleados.direccion = o.direccion;
                    empleados.telefono = o.telefono;
                    empleados.cargo = o.cargo;
                    empleados.sucursal = o.sucursal;
                    empleados.jefe = o.jefe;
                return Ok(empleadosBL.Update(empleados));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            [HttpDelete]
            [Route("v1/empleados/Delete")]
            public ActionResult Delete(string rut)
            {
                try
                {
                    empleados.rut = rut;
                    return Ok(empleadosBL.Delete(empleados));
                }
                catch (Exception ex)
                {
                    error = new ErrorResponse(ex);
                    return StatusCode(500, error);
                }

            }

            private List<EmpleadosDTO> convertList(List<Empleados> lista)
            {
                List<EmpleadosDTO> list = new List<EmpleadosDTO>();
                foreach (var item in lista)
                {
                    EmpleadosDTO el = new EmpleadosDTO(item.rut, item.nombre, item.apellido, item.direccion, item.telefono, item.cargo, item.sucursal, item.jefe);
                    list.Add(el);
                    
                }
                return list;

            }
            private EmpleadosDTO convert(Empleados item)
            {
                EmpleadosDTO obj= new EmpleadosDTO(item.rut, item.nombre, item.apellido, item.direccion, item.telefono, item.cargo, item.sucursal, item.jefe);
                return obj;

            }
    }
    }
