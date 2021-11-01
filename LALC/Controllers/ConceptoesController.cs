﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LALC.Models;
using PagedList;
using PagedList.Mvc;

namespace LALC.Controllers
{
    public class ConceptoesController : Controller
    {
        private LALCDb db = new LALCDb();

        // GET: Conceptoes
        public ActionResult Index(String TituloC)
        {
            var concepto = from s in db.Concepto select s;
            if (!String.IsNullOrEmpty(TituloC))
            {
                concepto = concepto.Where(s => s.Titulo.Contains(TituloC));
                return View(concepto.ToList());
            }
            return View(db.Concepto.ToList());
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

        /*[HttpPost]
        public ActionResult SpecificConcepts(String TituloC)
        {
            var concepto = from s in db.Concepto select s;
            if (!String.IsNullOrEmpty(TituloC))
            {
                concepto = concepto.Where(s => s.Titulo.Contains(TituloC));
                return View(concepto.ToList());
            }
            return View(db.Concepto.ToList());
        }*/
        public ActionResult SpecificConcepts(int? id, String TituloC, int? pagina)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var concepto = from s in db.Concepto select s;
            concepto = concepto.Where(s => s.SubcategoriaID == id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            if (!String.IsNullOrEmpty(TituloC))
            {
                concepto = concepto.Where(s => s.Titulo.Contains(TituloC));
                return View(concepto.ToList().ToPagedList(pagina ?? 1, 12));
            }
            return View(concepto.ToList().ToList().ToPagedList(pagina ?? 1, 12));
        }
        public ActionResult Practice(int? id)
        {
            var concepto = from s in db.Concepto select s;
            concepto = concepto.Where(s => s.SubcategoriaID == id);
            if (concepto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Random a = new Random();
            List<Concepto> conceptos = concepto.ToList();
            int v = a.Next(0, conceptos.Count);
            Concepto c_random = conceptos[v];
            if (c_random == null)
            {
                return HttpNotFound();
            }
            return View(c_random);
        }

        public int getItem(int id)
        {
            Random a = new Random();
            var concepto = from s in db.Concepto select s;
            concepto = concepto.Where(s => s.SubcategoriaID == id);
            return a.Next(0, concepto.ToList().Count);
        }

        // GET: Conceptoes/Create
        public ActionResult Create()
        {
            ViewBag.SubcategoriaID = new SelectList(db.Subcategoria, "SubcategoriaID", "Nombre");
            return View();
        }

        // POST: Conceptoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConceptoID,SubcategoriaID,Definicion,Titulo")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                db.Concepto.Add(concepto);
                db.SaveChanges();
                return RedirectToAction("SpecificConcepts", "Conceptoes", new { id = concepto.SubcategoriaID }); ;
            }

            ViewBag.SubcategoriaID = new SelectList(db.Subcategoria, "SubcategoriaID", "Nombre", concepto.SubcategoriaID);
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
            ViewBag.SubcategoriaID = new SelectList(db.Subcategoria, "SubcategoriaID", "Nombre", concepto.SubcategoriaID);
            return View(concepto);
        }

        // POST: Conceptoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConceptoID,SubcategoriaID,Definicion,Titulo")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concepto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubcategoriaID = new SelectList(db.Subcategoria, "SubcategoriaID", "Nombre", concepto.SubcategoriaID);
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
