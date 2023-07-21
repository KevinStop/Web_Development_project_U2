using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Web_development_project_U2.Models.ViewModels;

namespace Web_development_project_U2.Controllers
{
    public class LibroController : Controller
    {
        public ActionResult libro()
        {
            nt userId = (int)Session["UserId"];
            List<ListLibroViewModel> lst;
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                lst = (from c in db.Libros
                           //where c.id == userId
                       select new ListLibroViewModel
                       {
                           id = c.id,
                           titulo = c.titulo,
                           autor = c.autor,
                           anio_publicacion = c.anio_publicacion,
                           categoria = c.categoria
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

    }
}