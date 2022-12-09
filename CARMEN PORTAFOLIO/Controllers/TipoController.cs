using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARMEN_PORTAFOLIO.Models;

namespace CARMEN_PORTAFOLIO.Controllers
{
    public class TipoController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Tipo
        public ActionResult Index()
        {
            return View(db.Tipo.ToList());
        }

        // GET: Tipo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        // GET: Tipo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

        // GET: Tipo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tipo tipo = db.Tipo.Find(id);
            db.Tipo.Remove(tipo);
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
