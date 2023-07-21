using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_development_project_U2.Models.ViewModels;

namespace Web_development_project_U2.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult prestamo()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

    }
}