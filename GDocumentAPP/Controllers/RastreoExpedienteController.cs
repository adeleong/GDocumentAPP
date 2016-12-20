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
    public class RastreoExpedienteController : Controller
    {
        private GDocumentDBEntities db = new GDocumentDBEntities();

        // GET: RastreoExpediente
        public ActionResult Index()
        {
            var rASTREO_EXPEDIENTE = db.RASTREO_EXPEDIENTE.Include(r => r.DEPENDENCIA).Include(r => r.USUARIO);
            return View(rASTREO_EXPEDIENTE.ToList());
        }

        // GET: RastreoExpediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE = db.RASTREO_EXPEDIENTE.Find(id);
            if (rASTREO_EXPEDIENTE == null)
            {
                return HttpNotFound();
            }
            return View(rASTREO_EXPEDIENTE);
        }

        // GET: RastreoExpediente/Create
        public ActionResult Create()
        {
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE");
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN");
            return View();
        }

        // POST: RastreoExpediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RATRAEO_EXPEDIENTE_ID,EMPLEADO_ID,USUARIO_ID,DEPENDENCIA_ID,FECHA_SALIDA,FECHA_DEVOLUCION,FIRMA,ESTATUS_ID,PERSONA_ASIGNACION,COMENTARIO")] RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE)
        {
            if (ModelState.IsValid)
            {
                db.RASTREO_EXPEDIENTE.Add(rASTREO_EXPEDIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", rASTREO_EXPEDIENTE.DEPENDENCIA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", rASTREO_EXPEDIENTE.USUARIO_ID);
            return View(rASTREO_EXPEDIENTE);
        }

        // GET: RastreoExpediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE = db.RASTREO_EXPEDIENTE.Find(id);
            if (rASTREO_EXPEDIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", rASTREO_EXPEDIENTE.DEPENDENCIA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", rASTREO_EXPEDIENTE.USUARIO_ID);
            return View(rASTREO_EXPEDIENTE);
        }

        // POST: RastreoExpediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RATRAEO_EXPEDIENTE_ID,EMPLEADO_ID,USUARIO_ID,DEPENDENCIA_ID,FECHA_SALIDA,FECHA_DEVOLUCION,FIRMA,ESTATUS_ID,PERSONA_ASIGNACION,COMENTARIO")] RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rASTREO_EXPEDIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", rASTREO_EXPEDIENTE.DEPENDENCIA_ID);
            ViewBag.USUARIO_ID = new SelectList(db.USUARIOs, "USUARIO_ID", "LOGIN", rASTREO_EXPEDIENTE.USUARIO_ID);
            return View(rASTREO_EXPEDIENTE);
        }

        // GET: RastreoExpediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE = db.RASTREO_EXPEDIENTE.Find(id);
            if (rASTREO_EXPEDIENTE == null)
            {
                return HttpNotFound();
            }
            return View(rASTREO_EXPEDIENTE);
        }

        // POST: RastreoExpediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RASTREO_EXPEDIENTE rASTREO_EXPEDIENTE = db.RASTREO_EXPEDIENTE.Find(id);
            db.RASTREO_EXPEDIENTE.Remove(rASTREO_EXPEDIENTE);
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
