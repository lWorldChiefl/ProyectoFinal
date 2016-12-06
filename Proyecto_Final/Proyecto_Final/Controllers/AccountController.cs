using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Final.Controllers
{
    public class AccountController : Controller
    {
        private Proyecto_VerocoEntities db = new Proyecto_VerocoEntities();
        UsuariosRepository userRe = new UsuariosRepository();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configurar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Configurar(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                userRe.Actualizar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

    }
}