using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDocumentAPP;

namespace GDocumentAPP.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(db.TIPO_DOCUMENTO.ToList());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = db.TIPO_DOCUMENTO.Find(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TIPO_DOCUMENTO_ID,DESCRIPCION,REQUERIDO")] TIPO_DOCUMENTO tIPO_DOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_DOCUMENTO.Add(tIPO_DOCUMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_DOCUMENTO);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = db.TIPO_DOCUMENTO.Find(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TIPO_DOCUMENTO_ID,DESCRIPCION,REQUERIDO")] TIPO_DOCUMENTO tIPO_DOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_DOCUMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_DOCUMENTO);
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = db.TIPO_DOCUMENTO.Find(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_DOCUMENTO tIPO_DOCUMENTO = db.TIPO_DOCUMENTO.Find(id);
            db.TIPO_DOCUMENTO.Remove(tIPO_DOCUMENTO);
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
