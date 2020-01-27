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
    public class ROLLsController : Controller
    {
        private Practica1Programacion3Entities db = new Practica1Programacion3Entities();

        // GET: ROLLs
        public ActionResult Index()
        {
            return View(db.ROLL.ToList());
        }

        // GET: ROLLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLL rOLL = db.ROLL.Find(id);
            if (rOLL == null)
            {
                return HttpNotFound();
            }
            return View(rOLL);
        }

        // GET: ROLLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROLLs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Rol,Descripcion_Rol")] ROLL rOLL)
        {
            if (ModelState.IsValid)
            {
                db.ROLL.Add(rOLL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOLL);
        }

        // GET: ROLLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLL rOLL = db.ROLL.Find(id);
            if (rOLL == null)
            {
                return HttpNotFound();
            }
            return View(rOLL);
        }

        // POST: ROLLs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Rol,Descripcion_Rol")] ROLL rOLL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOLL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOLL);
        }

        // GET: ROLLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLL rOLL = db.ROLL.Find(id);
            if (rOLL == null)
            {
                return HttpNotFound();
            }
            return View(rOLL);
        }

        // POST: ROLLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROLL rOLL = db.ROLL.Find(id);
            db.ROLL.Remove(rOLL);
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
