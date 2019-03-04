using WebApi.Models;
using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using WebApi.Helpers;
using System.Web;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("Custo")]
    public class CustoController : ApiController
    {
        CustoService service = new CustoService();
        
        
        [Route("Get")]
        public IHttpActionResult Get()
        {
            try
            {
                List<Custo> custos = service.Get();
                return Json(custos);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("GetByDescricao/{descricao}")]
        public IHttpActionResult GetByDescricao(string descricao)
        {
            try
            {
                List<Custo> custos = service.GetByDescricao(descricao);
                return Json(custos);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("GetByDescricao")]
        public IHttpActionResult GetByDescricao()
        {
            try
            {
                List<Custo> custos = service.Get();
                return Json(custos);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("GetByFuncionarioId/{id}")]
        public IHttpActionResult GetByFuncionarioId(int id)
        {
            try
            {
                List<Custo> custos = service.GetByFuncionarioId(id);
                return Json(custos);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("Create")]
        public IHttpActionResult Create(Custo custo)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            try
            {
                service.Create(custo);
                return Content(HttpStatusCode.OK, "Despesa registrada com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar custo: " + e.Message);
            }
        }

        [Route("ImportarExcel")]
        public IHttpActionResult ImportarExcel()
        {

            var files = HttpContext.Current.Request.Files;

            var httpRequest = HttpContext.Current.Request;

            if (files.Count == 0)
                return Content(HttpStatusCode.BadRequest, new List<String> { "Arquivo não anexado." });


            try
            {
                foreach (string file in files)
                {
                    var postedFile = files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/temp/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    service.ImportarExcel(postedFile.FileName);
                }

                return Content(HttpStatusCode.OK, "Planilha importada com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, new List<String> { "Erro ao importar planilha: " + e.Message });
            }


        }

    }
}
