using E_Commerce.BusinnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.WebApp.Controllers
{
    //[RoutePrefix("Anasayfa")]
    //[Route("{action=Index}")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("~/Anasayfa")]

        [HttpGet]
        public ActionResult Index()
        {
            //Test test = new Test();
            return View();
        }
    }
}