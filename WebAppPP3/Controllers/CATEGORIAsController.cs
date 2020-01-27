﻿using System;
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
    public class CATEGORIAsController : Controller
    {
        private Practica1Programacion3Entities db = new Practica1Programacion3Entities();

        // GET: CATEGORIAs
        public ActionResult Index()
        {
            return View(db.CATEGORIA.ToList());
        }

        // GET: CATEGORIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA);
        }

        // GET: CATEGORIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Categoria,Descripcion")] CATEGORIA cATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA.Add(cATEGORIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA);
        }

        // GET: CATEGORIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA);
        }

        // POST: CATEGORIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Categoria,Descripcion")] CATEGORIA cATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA);
        }

        // GET: CATEGORIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA);
        }

        // POST: CATEGORIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            db.CATEGORIA.Remove(cATEGORIA);
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
