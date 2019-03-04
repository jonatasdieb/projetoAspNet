using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
   

    public class HomeController : Controller
    {
        public CustoService teste = new CustoService();

        // GET: Home
        public ActionResult Index()
        {           
            return View();
        }
    }
}