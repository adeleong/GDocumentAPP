using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDocumentAPP;
using PagedList;

namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class EstatusController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: Estatus
        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var estatus = from s in db.ESTATUS
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                estatus = estatus.Where(s => s.DESCRIPCION.Contains(searchString));
            }

            return View(estatus.ToList().ToPagedList(pageNumber, pageSize));

        }

        // GET: Estatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTATU eSTATU = db.ESTATUS.Find(id);
            if (eSTATU == null)
            {
                return HttpNotFound();
            }
            return View(eSTATU);
        }

        // GET: Estatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ESTATUS_ID,DESCRIPCION,TIPO,VALOR_LOGICO")] ESTATU eSTATU)
        {
            if (ModelState.IsValid)
            {
                db.ESTATUS.Add(eSTATU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTATU);
        }

        // GET: Estatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTATU eSTATU = db.ESTATUS.Find(id);
            if (eSTATU == null)
            {
                return HttpNotFound();
            }
            return View(eSTATU);
        }

        // POST: Estatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ESTATUS_ID,DESCRIPCION,TIPO,VALOR_LOGICO")] ESTATU eSTATU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTATU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTATU);
        }

        // GET: Estatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTATU eSTATU = db.ESTATUS.Find(id);
            if (eSTATU == null)
            {
                return HttpNotFound();
            }
            return View(eSTATU);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTATU eSTATU = db.ESTATUS.Find(id);
            db.ESTATUS.Remove(eSTATU);
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
