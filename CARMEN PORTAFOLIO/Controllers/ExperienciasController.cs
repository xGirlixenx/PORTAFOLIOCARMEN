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
    public class ExperienciasController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Experiencias
        public ActionResult Index()
        {
            var experiencia = db.Experiencia.Include(e => e.AspNetUsers).Include(e => e.Tipo);
            return View(experiencia.ToList());
        }

        // GET: Experiencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: Experiencias/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Tipo_ID = new SelectList(db.Tipo, "Id", "Descripcion");
            return View();
        }

        // POST: Experiencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioID,Tipo_ID,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Experiencia.Add(experiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipo, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // GET: Experiencias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipo, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // POST: Experiencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioID,Tipo_ID,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipo, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // GET: Experiencias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencia.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Experiencia experiencia = db.Experiencia.Find(id);
            db.Experiencia.Remove(experiencia);
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
