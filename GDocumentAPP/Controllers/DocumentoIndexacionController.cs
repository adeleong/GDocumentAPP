using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GDocumentAPP.Services;

namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class DocumentoIndexacionController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();
        // GET: DocumentoIndexacion
        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var documentoIndexacion = from s in db.DOCUMENTO_INDEXACION.Include(d => d.DOCUMENTO).Include(d => d.TIPO_DOCUMENTO).Include(d => d.USUARIO)
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                documentoIndexacion = documentoIndexacion.Where(s => s.DESCRIPCION.Contains(searchString));
            }

            return View(documentoIndexacion.ToList().ToPagedList(pageNumber, pageSize));

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
        public ActionResult Create(int? documentoId)
        {

            int? usuarioId = int.Parse(Session[Bundle.usuarioId].ToString());

            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes.Where(d => d.DOCUMENTO_ID ==  documentoId), "DOCUMENTO_ID", "NOMBRE_DOCUMENTO");
            ViewBag.TIPO_DOCUMENTO_ID = new SelectList(db.TIPO_DOCUMENTO, "TIPO_DOCUMENTO_ID", "DESCRIPCION");
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs.Where(u => u.USUARIO_ID == usuarioId), "USUARIO_ID", "LOGIN");

            DOCUMENTO documento = db.DOCUMENTOes.Find(documentoId);

            documento.ESTATUS_ID = (int)Bundle.Estatus.PendienteIndexar;

            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
            }

            DOCUMENTO_INDEXACION dOCUMENTO_INDEXACION = new DOCUMENTO_INDEXACION();
            dOCUMENTO_INDEXACION.DOCUMENTO = documento;


            return View(dOCUMENTO_INDEXACION);
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

                DOCUMENTO documento = db.DOCUMENTOes.Find(dOCUMENTO_INDEXACION.DOCUMENTO_ID);

                documento.ESTATUS_ID = (int)Bundle.Estatus.Completado;

                db.Entry(documento).State = EntityState.Modified;
                db.DOCUMENTO_INDEXACION.Add(dOCUMENTO_INDEXACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }   

            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "NOMBRE_DOCUMENTO", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
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
            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "NOMBRE_DOCUMENTO", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
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
            ViewBag.DOCUMENTO_ID = new SelectList(db.DOCUMENTOes, "DOCUMENTO_ID", "NOMBRE_DOCUMENTO", dOCUMENTO_INDEXACION.DOCUMENTO_ID);
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
