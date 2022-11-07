using System;
using System.Reflection;
using apiJuanXXIII.Helper;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace apiJuanXXIII.Controllers
{
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        DeptosBL deptoBL = new DeptosBL();
        Departamento departamento = new Departamento();
        ErrorResponse error;

        [HttpPost]
        [Route("v1/departamento/Create")]
        public ActionResult Create(DepartamentoDTO o)
        {
            try
            {
                departamento.cod_depto = o.cod_depto;
                departamento.nombre_depto = o.nombre_depto;
                return Ok(deptoBL.Create(departamento));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/departamento/Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(convertList(deptoBL.Get(departamento)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPost]
        [Route("v1/departamento/GetQuery")]
        public ActionResult GetQuery(string nombre_depto)
        {
            try
            {
                departamento.nombre_depto = nombre_depto;
                return Ok(convertList(deptoBL.GetQuery(departamento)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("v1/departamento/GetById")]
        public ActionResult GetById(int cod_depto)
        {
            try
            {
                departamento.cod_depto = cod_depto;
                departamento = deptoBL.GetById(departamento);
                if (departamento != null)
                    return Ok(convert(departamento));
                else
                    return StatusCode(404, departamento);
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpPut]
        [Route("v1/cdepartamento/Update")]
        public ActionResult Update(DepartamentoDTO o)
        {
            try
            {
                departamento.cod_depto = o.cod_depto;
                departamento.nombre_depto = o.nombre_depto;
                return Ok(deptoBL.Update(departamento));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("v1/departamento/Delete")]
        public ActionResult Delete(int cod_depto)
        {
            try
            {
                departamento.cod_depto = cod_depto;
                return Ok(deptoBL.Delete(departamento));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<DepartamentoDTO> convertList(List<Departamento> lista)
        {
            List<DepartamentoDTO> list = new List<DepartamentoDTO>();
            foreach (var item in lista)
            {
                DepartamentoDTO el = new DepartamentoDTO(item.cod_depto, item.nombre_depto);
                list.Add(el);

            }
            return list;

        }
        private DepartamentoDTO convert(Departamento item)
        {
            DepartamentoDTO obj = new DepartamentoDTO(item.cod_depto, item.nombre_depto);
            return obj;

        }
    }
}
