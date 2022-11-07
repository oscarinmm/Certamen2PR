using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiJuanXXIII.Controllers
{
    public class ColegioController : Controller
    {
        ColegioBL colegioBL = new ColegioBL();
        Colegio colegio = new Colegio();
        ErrorResponse error;

        [HttpPost]
        [Route("v1/colegio/Create")]
        public ActionResult Create(ColegioDTO o)
        {
            try
            {
                colegio = convert(o);
                return Ok(colegioBL.Create(colegio));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/colegio/Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(convertList(colegioBL.Get(colegio)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPost]
        [Route("v1/colegio/GetQuery")]
        public ActionResult GetQuery(string nombre)
        {
            try
            {
                colegio.nombre = nombre;
               return Ok(convertList(colegioBL.GetQuery(colegio)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/colegio/GetById")]
        public ActionResult GetById(string id)
        {
            try
            {
                colegio.codigo = id;
                colegio= colegioBL.GetById(colegio);
                if (colegio != null)
                    return Ok(convert(colegio));
                else
                    return StatusCode(404, colegio);
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpPut]
        [Route("v1/colegio/Update")]
        public ActionResult Update(ColegioDTO o)
        {
            try
            {
                colegio = convert(o);
                return Ok(colegioBL.Update(colegio));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("v1/colegio/Delete")]
        public ActionResult Delete(string codigo)
        {
            try
            {
                colegio.codigo = codigo;
                return Ok(colegioBL.Delete(colegio));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        private List<ColegioDTO> convertList(List<Colegio> lista)
        {
            List<ColegioDTO> list = new List<ColegioDTO>();
            foreach (var item in lista)
            {
                ColegioDTO el = new ColegioDTO(item.codigo, item.nombre, item.codigotipo, item.comuna, item.direccion, item.telefono, item.director, item.sector, item.movilizacion, item.texto, item.colacion, item.jornada, item.pme);
                list.Add(el);

            }
            return list;

        }
        private ColegioDTO convert(Colegio item)
        {
            ColegioDTO el = new ColegioDTO(item.codigo, item.nombre, item.codigotipo, item.comuna, item.direccion, item.telefono, item.director, item.sector, item.movilizacion, item.texto, item.colacion, item.jornada, item.pme);
            return el;

        }

        private Colegio convert(ColegioDTO item)
        {
            Colegio o = new Colegio();
            colegio.codigo = item.codigo;
            colegio.nombre = item.nombre;
            colegio.codigotipo = item.codigotipo;
            colegio.comuna = item.comuna;
            colegio.direccion = item.direccion;
            colegio.telefono = item.telefono;
            colegio.director = item.director;
            colegio.sector = item.sector;
            colegio.movilizacion = item.movilizacion;
            colegio.texto = item.texto;
            colegio.colacion = item.colacion;
            colegio.jornada = item.jornada;
            colegio.pme = item.pme;

            return o;

        }
    }
}

