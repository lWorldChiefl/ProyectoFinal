using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using BusinessLayer;

namespace Proyecto_Final.Controllers
{
    public class VerocoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario user)
        {
            UsuariosRepository userRe = new UsuariosRepository();
            userRe.Crear(user);
            ModelState.Clear();
            ViewBag.Message = user.userName + " registrado satisfactoriamente";
            return View();
        }
    }
}