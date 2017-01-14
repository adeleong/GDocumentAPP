using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class DocumentoIndexacionController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: DocumentoIndexacion
        public ActionResult Index()
        {
            var dOCUMENTO_INDEXACION = db.DOCUMENTO_INDEXACION.Include(d => d.DOCUMENTO).Include(d => d.TIPO_DOCUMENTO).Include(d => d.USUARIO);
            return View(dOCUMENTO_INDEXACION.ToList());
        }

        // GET: DocumentoIndexacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION = db.DOCUMENTO_INDEXACION.Find(id);
            if (dOCUMENTO_INDEXACION == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO_INDEXACION);
        }

        // GET: DocumentoIndexacion/Create
        public ActionResult Create()
        {
            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "CANAL_GENERACION");
            ViewBag.TIPO_DOCUMENTO_ID = new SelectList(db.TIPO_DOCUMENTO, "TIPO_DOCUMENTO_ID", "DESCRIPCION");
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN");
            return View();
        }

        // POST: DocumentoIndexacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INDEXACION_ID,DOCUMENTO_ID,FECHA_INDEXACION,TIPO_DOCUMENTO_ID,NIVEL_CALIDAD,CLAVE_DOCUMENTO,DESCRIPCION,USUARIO_ID")] DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION)
        {
            if (ModelState.IsValid)
            {
                db.DOCUMENTO_INDEXACION.Add(dOCUMENTO_INDEXACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "CANAL_GENERACION", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
            ViewBag.TIPO_DOCUMENTO_ID = new SelectList(db.TIPO_DOCUMENTO, "TIPO_DOCUMENTO_ID", "DESCRIPCION", dOCUMENTO_INDEXACION.TIPO_DOCUMENTO_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO_INDEXACION.USUARIO_ID);
            return View(dOCUMENTO_INDEXACION);
        }

        // GET: DocumentoIndexacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION = db.DOCUMENTO_INDEXACION.Find(id);
            if (dOCUMENTO_INDEXACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "CANAL_GENERACION", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
            ViewBag.TIPO_DOCUMENTO_ID = new SelectList(db.TIPO_DOCUMENTO, "TIPO_DOCUMENTO_ID", "DESCRIPCION", dOCUMENTO_INDEXACION.TIPO_DOCUMENTO_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO_INDEXACION.USUARIO_ID);
            return View(dOCUMENTO_INDEXACION);
        }

        // POST: DocumentoIndexacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INDEXACION_ID,DOCUMENTO_ID,FECHA_INDEXACION,TIPO_DOCUMENTO_ID,NIVEL_CALIDAD,CLAVE_DOCUMENTO,DESCRIPCION,USUARIO_ID")] DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENTO_INDEXACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "CANAL_GENERACION", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
            ViewBag.TIPO_DOCUMENTO_ID = new SelectList(db.TIPO_DOCUMENTO, "TIPO_DOCUMENTO_ID", "DESCRIPCION", dOCUMENTO_INDEXACION.TIPO_DOCUMENTO_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO_INDEXACION.USUARIO_ID);
            return View(dOCUMENTO_INDEXACION);
        }

        // GET: DocumentoIndexacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION = db.DOCUMENTO_INDEXACION.Find(id);
            if (dOCUMENTO_INDEXACION == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO_INDEXACION);
        }

        // POST: DocumentoIndexacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION = db.DOCUMENTO_INDEXACION.Find(id);
            db.DOCUMENTO_INDEXACION.Remove(dOCUMENTO_INDEXACION);
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
