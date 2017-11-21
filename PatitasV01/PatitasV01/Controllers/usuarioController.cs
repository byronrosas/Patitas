using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatitasV01.Models;

namespace PatitasV01.Controllers
{
    public class usuarioController : Controller
    {
        private BDD_PATITASEntitiesGeneral db = new BDD_PATITASEntitiesGeneral();

        // GET: usuario
        public ActionResult Index()
        {
            return View(db.tbl_usuario.ToList());
        }

        // GET: usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // GET: usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_codigo,usu_nombres,usu_apellidos,usu_correo,usu_telefono,usu_cedula,usu_tipo,usu_pass,usu_direccion")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tbl_usuario.Add(tbl_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_usuario);
        }

        // GET: usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_codigo,usu_nombres,usu_apellidos,usu_correo,usu_telefono,usu_cedula,usu_tipo,usu_pass,usu_direccion")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_usuario);
        }

        // GET: usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            db.tbl_usuario.Remove(tbl_usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
