using System;
using System.Reflection;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace apiJuanXXIII.Controllers
{
    [ApiController]
    public class CargoController : ControllerBase
    {
        CargoBL cargoBL = new CargoBL();
        Cargo cargo = new Cargo();
        ErrorResponse error;

        [HttpPost]
        [Route("v1/cargo/Create")]
        public ActionResult Create(CargoDTO o)
        {
            try
            {
                cargo.codigo = o.codigo;
                cargo.nombre = o.nombre;
                return Ok(cargoBL.Create(cargo));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/cargo/Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(convertList(cargoBL.Get(cargo)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPost]
        [Route("v1/cargo/GetQuery")]
        public ActionResult GetQuery(string nombre)
        {
            try
            {
                cargo.nombre = nombre;
                return Ok(convertList(cargoBL.GetQuery(cargo)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/cargo/GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                cargo.codigo = id;
                cargo = cargoBL.GetById(cargo);
                if (cargo != null)
                    return Ok(convert(cargo));
                else
                    return StatusCode(404, cargo);
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpPut]
        [Route("v1/cargo/Update")]
        public ActionResult Update(CargoDTO o)
        {
            try
            {
                cargo.codigo = o.codigo;
                cargo.nombre = o.nombre;
                return Ok(cargoBL.Update(cargo));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("v1/cargo/Delete")]
        public ActionResult Delete(int codigo)
        {
            try
            {
                cargo.codigo = codigo;
                return Ok(cargoBL.Delete(cargo));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<CargoDTO> convertList(List<Cargo> lista)
        {
            List<CargoDTO> list = new List<CargoDTO>();
            foreach (var item in lista)
            {
                CargoDTO el = new CargoDTO(item.codigo, item.nombre);
                list.Add(el);

            }
            return list;

        }
        private CargoDTO convert(Cargo item)
        {
            CargoDTO obj = new CargoDTO(item.codigo, item.nombre);
            return obj;

        }
    }
}
