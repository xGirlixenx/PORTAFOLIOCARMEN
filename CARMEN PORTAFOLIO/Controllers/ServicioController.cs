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
    public class ServicioController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Servicio
        public ActionResult Index()
        {
            var servicios = db.Servicios.Include(s => s.AspNetUsers);
            return View(servicios.ToList());
        }

        // GET: Servicio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Servicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioID,Descripcion,Servicio,Descripcion_Servicio")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", servicios.UsuarioID);
            return View(servicios);
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", servicios.UsuarioID);
            return View(servicios);
        }

        // POST: Servicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioID,Descripcion,Servicio,Descripcion_Servicio")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", servicios.UsuarioID);
            return View(servicios);
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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
