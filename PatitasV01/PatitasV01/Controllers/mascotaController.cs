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
    public class mascotaController : Controller
    {
        private BDD_PATITASEntitiesGeneral db = new BDD_PATITASEntitiesGeneral();

        // GET: mascota
        public ActionResult Index()
        {
            var tbl_mascota = db.tbl_mascota.Include(t => t.tbl_tiposMascota);
            return View(tbl_mascota.ToList());
        }

        // GET: mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascota tbl_mascota = db.tbl_mascota.Find(id);
            if (tbl_mascota == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mascota);
        }

        // GET: mascota/Create
        public ActionResult Create()
        {
            ViewBag.tim_codigo = new SelectList(db.tbl_tiposMascota, "tim_codigo", "tim_nombre");
            return View();
        }

        // POST: mascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mas_codigo,mas_nombre,mas_fecha_nac,mas_raza,tim_codigo,mas_sexo")] tbl_mascota tbl_mascota)
        {
            if (ModelState.IsValid)
            {
                db.tbl_mascota.Add(tbl_mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tim_codigo = new SelectList(db.tbl_tiposMascota, "tim_codigo", "tim_nombre", tbl_mascota.tim_codigo);
            return View(tbl_mascota);
        }

        // GET: mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascota tbl_mascota = db.tbl_mascota.Find(id);
            if (tbl_mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.tim_codigo = new SelectList(db.tbl_tiposMascota, "tim_codigo", "tim_nombre", tbl_mascota.tim_codigo);
            return View(tbl_mascota);
        }

        // POST: mascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mas_codigo,mas_nombre,mas_fecha_nac,mas_raza,tim_codigo,mas_sexo")] tbl_mascota tbl_mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tim_codigo = new SelectList(db.tbl_tiposMascota, "tim_codigo", "tim_nombre", tbl_mascota.tim_codigo);
            return View(tbl_mascota);
        }

        // GET: mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascota tbl_mascota = db.tbl_mascota.Find(id);
            if (tbl_mascota == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mascota);
        }

        // POST: mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_mascota tbl_mascota = db.tbl_mascota.Find(id);
            db.tbl_mascota.Remove(tbl_mascota);
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
