using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Final.Controllers
{
    public class ProductosController : Controller
    {
        private Proyecto_VerocoEntities db = new Proyecto_VerocoEntities();
        ProductosRepository proRe = new ProductosRepository();

        // GET: Productos
        public ActionResult Productos()
        {
            var productosDatos = proRe.Listar;
            return View(productosDatos);
        }
    }
}