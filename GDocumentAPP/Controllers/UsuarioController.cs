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
using GDocumentAPP.Services;
using GDocumentAPP.Models;

namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: Usuario
        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var usuario = from u in db.USUARIOs.Include(u => u.ESTATU)
                          select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                usuario = usuario.Where(u => u.LOGIN.Contains(searchString)
                                          || u.PERSONA.NOMBRE.Contains(searchString)
                                          || u.PERSONA.PRIMER_APELLIDO.Contains(searchString)
                                          || u.PERSONA.IDENTIFICACION.Equals(searchString));
            }

            return View(usuario.ToList().ToPagedList(pageNumber, pageSize));

        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ListaValoresPersona ListaPersona = new ListaValoresPersona();

            var ListaValoresPersona = ListaPersona.getListaPersona();

            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION");
            ViewBag.PERSONA_ID = new SelectList(ListaValoresPersona, "PersonaId", "PersonaDescripcion");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USUARIO_ID,ESTATUS_ID,PERSONA_ID,LOGIN,CONTRASENIA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOs.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION");
            return View(uSUARIO);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }

            ListaValoresPersona ListaPersona = new ListaValoresPersona();
            var ListaValoresPersona = ListaPersona.getListaPersonaById(uSUARIO.PERSONA_ID);

            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION");
            ViewBag.PERSONA_ID = new SelectList(ListaValoresPersona , "PersonaId", "PersonaDescripcion");

            return View(uSUARIO);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USUARIO_ID,ESTATUS_ID,PERSONA_ID,LOGIN,CONTRASENIA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION");
            return View(uSUARIO);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            db.USUARIOs.Remove(uSUARIO);
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
