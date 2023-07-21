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

        [HttpPost]
        public ActionResult Nuevo(LibroViewModel libroModel)
        {
            try
            {
                //Sintáxis para agregar la imagen
                HttpPostedFileBase FileBase = Request.Files[0];

                if (FileBase != null && FileBase.ContentLength > 0)
                {
                    // Si el campo de imagen tiene contenido, crear el WebImage
                    WebImage image = new WebImage(FileBase.InputStream);
                    libroModel.imagen = image.GetBytes();
                }
                else
                {
                    // Si el campo de imagen está vacío, asignar un valor nulo o un arreglo de bytes vacío
                    libroModel.imagen = null; // o libroModel.imagen = new byte[0];
                }

                if (ModelState.IsValid)
                {
                    using (bibliotecaEntities db = new bibliotecaEntities())
                    {
                        var oLibro = new Libros();
                        oLibro.titulo = libroModel.titulo;
                        oLibro.autor = libroModel.autor;
                        oLibro.anio_publicacion = libroModel.anio_publicacion;
                        oLibro.categoria = libroModel.categoria;
                        oLibro.imagen = libroModel.imagen;

                        db.Libros.Add(oLibro);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Home/Admin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public ActionResult Editar()
        {
            return View();
        }

    }
}