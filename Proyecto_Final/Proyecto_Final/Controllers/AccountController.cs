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

        public ActionResult Eliminar(int? id)
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

        [HttpPost, ActionName("Delete")]
        public ActionResult Eliminar(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            userRe.Eliminar(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Usuarios()
        {
            var usuariosAdministrador = db.Usuarios.Where(u => u.userTypeId == 3 || u.userTypeId == 2);
            var usuariosGerente = db.Usuarios.Where(u => u.userTypeId == 2);
            if (Session["userTypeId"].ToString() == "1") //Administrador
            {
                return View(usuariosAdministrador.ToList());   
            }
            else //Gerente
            {
                return View(usuariosGerente.ToList());
            }
        }


    }
}