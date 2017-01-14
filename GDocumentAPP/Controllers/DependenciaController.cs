using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class DependenciaController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: Dependencia
      

        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var dependencia = from s in db.DEPENDENCIAs
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                dependencia = dependencia.Where(s => s.DEPENDENCIA_NOMBRE.Contains(searchString));
            }

            return View(dependencia.ToList().ToPagedList(pageNumber, pageSize));

        }


        // GET: Dependencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIA dEPENDENCIA = db.DEPENDENCIAs.Find(id);
            if (dEPENDENCIA == null)
            {
                return HttpNotFound();
            }
            return View(dEPENDENCIA);
        }

        // GET: Dependencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dependencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPENDENCIA_ID,DEPENDENCIA_NOMBRE")] DEPENDENCIA dEPENDENCIA)
        {
            if (ModelState.IsValid)
            {
                db.DEPENDENCIAs.Add(dEPENDENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPENDENCIA);
        }

        // GET: Dependencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIA dEPENDENCIA = db.DEPENDENCIAs.Find(id);
            if (dEPENDENCIA == null)
            {
                return HttpNotFound();
            }
            return View(dEPENDENCIA);
        }

        // POST: Dependencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPENDENCIA_ID,DEPENDENCIA_NOMBRE")] DEPENDENCIA dEPENDENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPENDENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPENDENCIA);
        }

        // GET: Dependencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIA dEPENDENCIA = db.DEPENDENCIAs.Find(id);
            if (dEPENDENCIA == null)
            {
                return HttpNotFound();
            }
            return View(dEPENDENCIA);
        }

        // POST: Dependencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPENDENCIA dEPENDENCIA = db.DEPENDENCIAs.Find(id);
            db.DEPENDENCIAs.Remove(dEPENDENCIA);
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
