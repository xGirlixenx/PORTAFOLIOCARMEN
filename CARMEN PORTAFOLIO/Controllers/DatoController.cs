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
    public class DatoController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Dato
        public ActionResult Index()
        {
            var datos = db.Datos.Include(d => d.AspNetUsers);
            return View(datos.ToList());
        }

        // GET: Dato/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // GET: Dato/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Dato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Clientes,Texto,UsuarioId,Descripcion_Hecho")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Datos.Add(datos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", datos.UsuarioId);
            return View(datos);
        }

        // GET: Dato/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", datos.UsuarioId);
            return View(datos);
        }

        // POST: Dato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Clientes,Texto,UsuarioId,Descripcion_Hecho")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", datos.UsuarioId);
            return View(datos);
        }

        // GET: Dato/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: Dato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Datos datos = db.Datos.Find(id);
            db.Datos.Remove(datos);
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
