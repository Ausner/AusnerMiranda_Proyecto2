using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AusnerMiranda_Proyecto2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult colaborador()
        {
            return View();
        }

        public ActionResult lista_colaboradores()
        {
            return View();
        }

        public ActionResult herramienta()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult prestamos()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}