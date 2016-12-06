using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using BusinessLayer;
using Microsoft.Owin.Security;

namespace Proyecto_Final.Controllers
{
    public class VerocoController : Controller
    {
        UsuariosRepository userRe = new UsuariosRepository();
        Proyecto_VerocoEntities db = new Proyecto_VerocoEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            using (db)
            {
                var usr = db.Usuarios.Where(u => u.userName == user.userName && u.userPassword == user.userPassword).FirstOrDefault();
                if (user != null)
                {
                    Session["userId"] = user.userId.ToString();
                    Session["userName"] = user.userName.ToString();
                    Session["userTypeId"] = user.userTypeId.ToString();
                    return RedirectToAction("Logged");
                }
                else
                {
                    ModelState.AddModelError("","Username or Password is wrong");
                }
            }            
            return View();
        }

        public ActionResult Logged()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Veroco");
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario user)
        {
            userRe.Crear(user);
            ModelState.Clear();
            ViewBag.Message = user.userName + " registrado satisfactoriamente";
            return View();
        }
    }
}