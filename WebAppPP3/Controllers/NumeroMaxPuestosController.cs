using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPP3.Models;

namespace WebAppPP3.Controllers
{
    public class NumeroMaxPuestosController : Controller
    {
        private Practica1Programacion3Entities db = new Practica1Programacion3Entities();

        // GET: NumeroMaxPuestos
        public ActionResult Index()
        {
            return View(db.NumeroMaxPuestos.ToList());
        }

        // GET: NumeroMaxPuestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroMaxPuestos numeroMaxPuestos = db.NumeroMaxPuestos.Find(id);
            if (numeroMaxPuestos == null)
            {
                return HttpNotFound();
            }
            return View(numeroMaxPuestos);
        }

        // GET: NumeroMaxPuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumeroMaxPuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CantidadPuestos")] NumeroMaxPuestos numeroMaxPuestos)
        {
            if (ModelState.IsValid)
            {
                db.NumeroMaxPuestos.Add(numeroMaxPuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(numeroMaxPuestos);
        }

        // GET: NumeroMaxPuestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroMaxPuestos numeroMaxPuestos = db.NumeroMaxPuestos.Find(id);
            if (numeroMaxPuestos == null)
            {
                return HttpNotFound();
            }
            return View(numeroMaxPuestos);
        }

        // POST: NumeroMaxPuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CantidadPuestos")] NumeroMaxPuestos numeroMaxPuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numeroMaxPuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(numeroMaxPuestos);
        }

        // GET: NumeroMaxPuestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroMaxPuestos numeroMaxPuestos = db.NumeroMaxPuestos.Find(id);
            if (numeroMaxPuestos == null)
            {
                return HttpNotFound();
            }
            return View(numeroMaxPuestos);
        }

        // POST: NumeroMaxPuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumeroMaxPuestos numeroMaxPuestos = db.NumeroMaxPuestos.Find(id);
            db.NumeroMaxPuestos.Remove(numeroMaxPuestos);
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
