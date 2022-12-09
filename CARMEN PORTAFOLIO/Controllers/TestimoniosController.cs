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
    public class TestimoniosController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Testimonios
        public ActionResult Index()
        {
            var testimonio = db.Testimonio.Include(t => t.AspNetUsers);
            return View(testimonio.ToList());
        }

        // GET: Testimonios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // GET: Testimonios/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Testimonios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Testimonio.Add(testimonio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // POST: Testimonios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // POST: Testimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Testimonio testimonio = db.Testimonio.Find(id);
            db.Testimonio.Remove(testimonio);
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
