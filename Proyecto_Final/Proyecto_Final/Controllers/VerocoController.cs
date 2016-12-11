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
                if (usr != null)
                {
                    Session["userId"] = usr.userId;
                    Session["userName"] = usr.userName.ToString();
                    Session["userTypeId"] = usr.userTypeId;
                    return RedirectToAction("Index","Account");
                }
                else
                {
                    ModelState.AddModelError("","Usuario or Password incorrecta");
                }
            }            
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Veroco");
        }

        public ActionResult Registrarse()
        {
            ViewBag.tipo_id = new SelectList(db.Tipos_Usuarios, "userTypeId", "userTypeDescription",1);
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario user)
        {
            ViewBag.Message = user.userName + " registrado satisfactoriamente";
            ViewBag.tipo_id = new SelectList(db.Tipos_Usuarios, "userTypeId", "userTypeDescription", 1);
            userRe.Crear(user);
            ModelState.Clear();
            return Redirect("Login");
        }
    }
}