using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPP3.Models;
using PagedList;

namespace WebAppPP3.Controllers
{
    public class PUESTOSController : Controller
    {
        private Practica1Programacion3Entities db = new Practica1Programacion3Entities();
        
        // GET: PUESTOS
        public ActionResult Index(string sortOrder)
        {
           
            var pUESTOS = db.PUESTOS.Include(p => p.CATEGORIA);
            return View(pUESTOS.ToList());
        }

        // GET: PUESTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTOS pUESTOS = db.PUESTOS.Find(id);
            if (pUESTOS == null)
            {
                return HttpNotFound();
            }
            return View(pUESTOS);
        }
        public ActionResult Detailsusr(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTOS pUESTOS = db.PUESTOS.Find(id);
            if (pUESTOS == null)
            {
                return HttpNotFound();
            }
            return View(pUESTOS);
        }

        // GET: PUESTOS/Create
        public ActionResult Create()
        {
            ViewBag.Id_Categoria = new SelectList(db.CATEGORIA, "Id_Categoria", "Descripcion");
            return View();
        }

        // POST: PUESTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_puestos,Ubicacion,Posicion,Empresa,Horario,foto,Descripcion,Salario,Fecha_Publicacion,Id_Categoria")] PUESTOS pUESTOS)
        {
            if (ModelState.IsValid)
            {
                db.PUESTOS.Add(pUESTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Categoria = new SelectList(db.CATEGORIA, "Id_Categoria", "Descripcion", pUESTOS.Id_Categoria);
            return View(pUESTOS);
        }

        // GET: PUESTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTOS pUESTOS = db.PUESTOS.Find(id);
            if (pUESTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Categoria = new SelectList(db.CATEGORIA, "Id_Categoria", "Descripcion", pUESTOS.Id_Categoria);
            return View(pUESTOS);
        }

        // POST: PUESTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_puestos,Ubicacion,Posicion,Empresa,Horario,foto,Descripcion,Salario,Fecha_Publicacion,Id_Categoria")] PUESTOS pUESTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUESTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Categoria = new SelectList(db.CATEGORIA, "Id_Categoria", "Descripcion", pUESTOS.Id_Categoria);
            return View(pUESTOS);
        }

        // GET: PUESTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTOS pUESTOS = db.PUESTOS.Find(id);
            if (pUESTOS == null)
            {
                return HttpNotFound();
            }
            return View(pUESTOS);
        }

        // POST: PUESTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUESTOS pUESTOS = db.PUESTOS.Find(id);
            db.PUESTOS.Remove(pUESTOS);
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

        public ActionResult Publicaciones(int CantItem = 10, int getcategorias = 0, String BuscarPuestos = "")
        {
          
            var PUESTOS = db.PUESTOS;
            var dbcategoria = db.CATEGORIA;
            var dbcant = db.NumeroMaxPuestos;

            CantItem = dbcant.Select(s => s.CantidadPuestos).FirstOrDefault();

            List<SelectListItem> lst = new List<SelectListItem>();

            

            lst = dbcategoria.Select(x => new SelectListItem() { Text = x.Descripcion, Value = x.Id_Categoria.ToString()}).ToList();

            lst.Add(new SelectListItem() { Text = "Todos", Value = "0" });

            lst.OrderBy(s=>s.Value);

            ViewData["getcategorias"] = lst;

           

            if (!String.IsNullOrEmpty(BuscarPuestos))
            {

                ViewBag.CantidadItem = PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).Where(s => s.Posicion.Contains(BuscarPuestos)).ToList().Take(CantItem).Count();

                return View(PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).Where(s => s.Posicion.Contains(BuscarPuestos)).ToList().Take(CantItem));


            }
            else if (getcategorias == 0)
            {
                ViewBag.CantidadItem = PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).ToList().Take(CantItem).Count();
                return View(PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).ToList().Take(CantItem));
            }
            else
            {
                ViewBag.CantidadItem = PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).Where(C => C.Id_Categoria == getcategorias).ToList().Take(CantItem).Count();
                return View(PUESTOS.OrderByDescending(s => s.Fecha_Publicacion).Where(C => C.Id_Categoria == getcategorias).ToList().Take(CantItem));

            }

           

        }

        





    }
}
