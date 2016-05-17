using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimQ_MVC_Oef.Models;

namespace TimQ_MVC_Oef.Controllers
{
    public class ComponentsController : Controller
    {
        private TimQ_MVC_OefContext db = new TimQ_MVC_OefContext();

        // GET: Components
        //public ActionResult Index()
        //{
        //    var components = db.Components.Include(c => c.Categorie);
        //    return View(components.ToList());
        //}

        public ActionResult Index(string Sorting_Order, string Search_Data)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Categorie" : "";
        
            var components = db.Components.Include(c => c.Categorie);                          

            if (Sorting_Order=="Categorie")
            {
                components = db.Components.Include(c => c.Categorie).OrderByDescending(c => c.Categorie.Naam);
            }
            else
            {
                components = db.Components.Include(c => c.Categorie).OrderBy(c => c.Categorie.Naam);
            }

            if (Search_Data != null)
            {
                components = components.Include(c => c.Categorie).Where(c => c.Naam.ToUpper().Contains(Search_Data.ToUpper()));
            }

            return View(components.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Naam");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComponentID,CategorieID,Naam,DataSheetLink,Aantal,Aankoopprijs")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Components.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Naam", component.CategorieID);
            return View(component);
        }

        // GET: Components/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Naam", component.CategorieID);
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComponentID,CategorieID,Naam,DataSheetLink,Aantal,Aankoopprijs")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Naam", component.CategorieID);
            return View(component);
        }

        // GET: Components/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Components.Find(id);
            db.Components.Remove(component);
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
