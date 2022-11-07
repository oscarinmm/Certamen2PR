using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiJuanXXIII.Controllers
{
    public class ComunaController : Controller
    {
        ComunaBL comunaBL = new ComunaBL();
        Comuna comuna = new Comuna();
        ErrorResponse error;

        [HttpPost]
        [Route("v1/comuna/Create")]
        public ActionResult Create(ComunaDTO o)
        {
            try
            {
                comuna.codigo = o.codigo;
                comuna.nombre = o.nombre;
                return Ok(comunaBL.Create(comuna));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/comuna/Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(convertList(comunaBL.Get(comuna)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPost]
        [Route("v1/comuna/GetQuery")]
        public ActionResult GetQuery(string nombre)
        {
            try
            {
                comuna.nombre = nombre;
                return Ok(convertList(comunaBL.GetQuery(comuna)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/comuna/GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                comuna.codigo = id;
                comuna = comunaBL.GetById(comuna);
                if (comuna != null)
                    return Ok(convert(comuna));
                else
                    return StatusCode(404, comuna);
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpPut]
        [Route("v1/comuna/Update")]
        public ActionResult Update(ComunaDTO o)
        {
            try
            {
                comuna.codigo = o.codigo;
                comuna.nombre = o.nombre;
                return Ok(comunaBL.Update(comuna));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("v1/comuna/Delete")]
        public ActionResult Delete(int codigo)
        {
            try
            {
                comuna.codigo = codigo;
                return Ok(comunaBL.Delete(comuna));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        private List<ComunaDTO> convertList(List<Comuna> lista)
        {
            List<ComunaDTO> list = new List<ComunaDTO>();
            foreach (var item in lista)
            {
                ComunaDTO el = new ComunaDTO(item.codigo, item.nombre);
                list.Add(el);

            }
            return list;

        }
        private ComunaDTO convert(Comuna item)
        {
            ComunaDTO el = new ComunaDTO(item.codigo, item.nombre);
            return el;

        }
    }
}

