using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LALC.Models;

namespace LALC.Controllers
{
    public class ConceptoesController : Controller
    {
        private LALCDb db = new LALCDb();

        // GET: Conceptoes
        public ActionResult Index()
        {
            var concepto = db.Concepto.Include(c => c.Categoria);
            return View(concepto.ToList());
        }

        // GET: Conceptoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concepto concepto = db.Concepto.Find(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        // GET: Conceptoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nombre");
            return View();
        }

        // POST: Conceptoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConceptoID,CategoriaID,Definicion,Titulo")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                db.Concepto.Add(concepto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nombre", concepto.CategoriaID);
            return View(concepto);
        }

        // GET: Conceptoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concepto concepto = db.Concepto.Find(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nombre", concepto.CategoriaID);
            return View(concepto);
        }

        // POST: Conceptoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConceptoID,CategoriaID,Definicion,Titulo")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concepto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nombre", concepto.CategoriaID);
            return View(concepto);
        }

        // GET: Conceptoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concepto concepto = db.Concepto.Find(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        // POST: Conceptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Concepto concepto = db.Concepto.Find(id);
            db.Concepto.Remove(concepto);
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
