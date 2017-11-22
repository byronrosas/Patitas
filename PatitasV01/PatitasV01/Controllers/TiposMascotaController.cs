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
    public class TiposMascotaController : Controller
    {
        private BDD_PATITASEntitiesGeneral db = new BDD_PATITASEntitiesGeneral();

        // GET: TiposMascota
        public ActionResult Index()
        {
            return View(db.tbl_tiposMascota.ToList());
        }

        // GET: TiposMascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tiposMascota tbl_tiposMascota = db.tbl_tiposMascota.Find(id);
            if (tbl_tiposMascota == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tiposMascota);
        }

        // GET: TiposMascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposMascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tim_codigo,tim_nombre,tim_descripcion")] tbl_tiposMascota tbl_tiposMascota)
        {
            if (ModelState.IsValid)
            {
                db.tbl_tiposMascota.Add(tbl_tiposMascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tiposMascota);
        }

        // GET: TiposMascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tiposMascota tbl_tiposMascota = db.tbl_tiposMascota.Find(id);
            if (tbl_tiposMascota == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tiposMascota);
        }

        // POST: TiposMascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tim_codigo,tim_nombre,tim_descripcion")] tbl_tiposMascota tbl_tiposMascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tiposMascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tiposMascota);
        }

        // GET: TiposMascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tiposMascota tbl_tiposMascota = db.tbl_tiposMascota.Find(id);
            if (tbl_tiposMascota == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tiposMascota);
        }

        // POST: TiposMascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_tiposMascota tbl_tiposMascota = db.tbl_tiposMascota.Find(id);
            db.tbl_tiposMascota.Remove(tbl_tiposMascota);
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
