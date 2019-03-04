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
    [RoutePrefix("Departamento")]
    public class DepartamentoController : ApiController
    {
        DepartamentoService service = new DepartamentoService();
        
        [Route("Get")]
        public IHttpActionResult Get()
        {
            try
            {
                List<Departamento> departamentos = service.Get();
                return Json(departamentos);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("Create")]
        public IHttpActionResult Create(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            try
            {
                service.Create(departamento);
                return Content(HttpStatusCode.OK, "Departamento criado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar departamento: " + e.Message);
            }

        }
    }
}
