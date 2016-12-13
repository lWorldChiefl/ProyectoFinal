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
        CategoriasRepository categoryRe = new CategoriasRepository();
        TiposUsuariosRepository typeUsersRe = new TiposUsuariosRepository();

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

        [HttpPost, ActionName("Eliminar")]
        public ActionResult Eliminar(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            userRe.Eliminar(usuario);
            return RedirectToAction("Usuarios");
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

        [HttpGet]
        public ActionResult Categorias()
        {
            var categoryDatos = categoryRe.Listar;
            return View(categoryDatos);
        }

        public ActionResult CrearCategorias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCategorias(Categoria category)
        {
            categoryRe.Crear(category);
            return RedirectToAction("Categorias");
        }

        public ActionResult EditarCategorias(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult EditarCategorias(Categoria category)
        {
            if (ModelState.IsValid)
            {
                categoryRe.Actualizar(category);
                return RedirectToAction("Categorias");
            }
            return View(category);
        }

        public ActionResult EliminarCategorias(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost, ActionName("EliminarCategorias")]
        public ActionResult EliminarCategorias(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Categorias");
        }

        /*                      Tipos de Usuarios                  */

        [HttpGet]
        public ActionResult Tipos_Usuarios()
        {
            var typeDatos = typeUsersRe.Listar;
            return View(typeDatos);
        }

        public ActionResult CrearTiposUsuarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearTiposUsuarios(Tipos_Usuarios category)
        {
            typeUsersRe.Crear(category);
            return RedirectToAction("Tipos_Usuarios");
        }

        public ActionResult EditarTiposUsuarios(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Usuarios tiposUsuarios = db.Tipos_Usuarios.Find(id);
            if (tiposUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tiposUsuarios);
        }

        [HttpPost]
        public ActionResult EditarTiposUsuarios(Tipos_Usuarios category)
        {
            if (ModelState.IsValid)
            {
                typeUsersRe.Actualizar(category);
                return RedirectToAction("Tipos_Usuarios");
            }
            return View(category);
        }

        public ActionResult EliminarTiposUsuarios(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Usuarios tiposUsuarios = db.Tipos_Usuarios.Find(id);
            if (tiposUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tiposUsuarios);
        }

        [HttpPost, ActionName("EliminarTiposUsuarios")]
        public ActionResult EliminarTiposUsuarios(int id)
        {
            Tipos_Usuarios tiposUsuarios = db.Tipos_Usuarios.Find(id);
            db.Tipos_Usuarios.Remove(tiposUsuarios);
            db.SaveChanges();
            return RedirectToAction("Tipos_Usuarios");
        }

    }
}