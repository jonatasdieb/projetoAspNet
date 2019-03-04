using WebApi.Models;
using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("Funcionario")]
    public class FuncionarioController : ApiController
    {
        FuncionarioService service = new FuncionarioService();   

        [Route("GetByDepartamentoId/{id}")]
        public IHttpActionResult GetByDepartamentoId(int id)
        {
            try
            {
                List<Funcionario> funcionarios = service.GetByDepartamentoId(id);
                return Json(funcionarios);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("Get")]
        public IHttpActionResult Get()
        {
            try
            {
                List<Funcionario> funcionarios= service.Get();
                return Json(funcionarios);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("Create")]
        public IHttpActionResult Create(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            try
                {
                    service.Create(funcionario);
                    return Content(HttpStatusCode.OK, "Funcionário cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar funcionário: " + e.Message);
                }
           
        }

    }
}