using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GDocumentAPP.Context;

namespace GDocumentAPP.Controllers
{
    public class PersonaController : Controller
    {
        private GDocumentDBEntities db = new GDocumentDBEntities();

        // GET: Persona
        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var personas = from s in db.PERSONAs
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                personas = personas.Where(s => s.NOMBRE.Contains(searchString)
                                            || s.PRIMER_APELLIDO.Contains(searchString)
                                            || s.IDENTIFICACION.Equals(searchString) );
            }

           // return View(db.PERSONAs.ToList().ToPagedList(pageNumber, pageSize));
            return View(personas.ToList().ToPagedList(pageNumber, pageSize));

        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PERSONA_ID,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TIPO_IDENTIFICACION,IDENTIFICACION,SEXO,EMAIL")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
              
                db.PERSONAs.Add(pERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERSONA);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PERSONA_ID,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TIPO_IDENTIFICACION,IDENTIFICACION,SEXO,EMAIL")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERSONA);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONA pERSONA = db.PERSONAs.Find(id);
            db.PERSONAs.Remove(pERSONA);
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
