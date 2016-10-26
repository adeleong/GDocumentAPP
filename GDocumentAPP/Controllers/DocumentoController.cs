using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDocumentAPP.Context;

namespace GDocumentAPP.Controllers
{
    public class DocumentoController : Controller
    {
        private GDocumentDBEntities db = new GDocumentDBEntities();

        // GET: Documento
        public ActionResult Index()
        {
            var dOCUMENTOes = db.DOCUMENTOes.Include(d => d.EMPLEADO).Include(d => d.ESTATU).Include(d => d.USUARIO);
            return View(dOCUMENTOes.ToList());
        }

        // GET: Documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR");
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS, "ESTATUS_ID", "DESCRIPCION");
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN");
            return View();
        }

        // POST: Documento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DOCUMENTO_ID,EMPLEADO_ID,CANAL_GENERACION,DOCUMENTO_DATA,FECHA_CREACION,USUARIO_ID,EXTENSION,SIZE,NOMBRE_DOCUMENTO,ESTATUS_ID")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DOCUMENTOes.Add(dOCUMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR", dOCUMENTO.EMPLEADO_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS, "ESTATUS_ID", "DESCRIPCION", dOCUMENTO.ESTATUS_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO.USUARIO_ID);
            return View(dOCUMENTO);
        }

        // GET: Documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR", dOCUMENTO.EMPLEADO_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS, "ESTATUS_ID", "DESCRIPCION", dOCUMENTO.ESTATUS_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO.USUARIO_ID);
            return View(dOCUMENTO);
        }

        // POST: Documento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DOCUMENTO_ID,EMPLEADO_ID,CANAL_GENERACION,DOCUMENTO_DATA,FECHA_CREACION,USUARIO_ID,EXTENSION,SIZE,NOMBRE_DOCUMENTO,ESTATUS_ID")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR", dOCUMENTO.EMPLEADO_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS, "ESTATUS_ID", "DESCRIPCION", dOCUMENTO.ESTATUS_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", dOCUMENTO.USUARIO_ID);
            return View(dOCUMENTO);
        }

        // GET: Documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            db.DOCUMENTOes.Remove(dOCUMENTO);
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
