using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private UserService service = new UserService();

        [Route("Cadastrar")]
        public IHttpActionResult Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            try
            {
                service.Create(user);
                return Content(HttpStatusCode.OK, "Usuário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, new List<String> { e.Message });
            }
        }

    }
}
