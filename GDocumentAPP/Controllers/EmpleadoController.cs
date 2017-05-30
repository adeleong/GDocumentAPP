﻿using GDocumentAPP.Models;
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
    public class EmpleadoController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        PERSONA persona = new PERSONA();

        // GET: Empleado
        public ActionResult Index(int? page, string searchString)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var eMPLEADOes = db.EMPLEADOes.Include(e => e.DEPENDENCIA).Include(e => e.ESTATU).Include(e => e.PERSONA);

            bool hayDatoEnSearch = String.IsNullOrEmpty(searchString) ? false : true;

            var empleados = from d in db.EMPLEADOes.Include(e => e.DEPENDENCIA).Include(e => e.ESTATU).Include(e => e.PERSONA)
                            select d;

            if (hayDatoEnSearch)
            {
                empleados = empleados.Where(e => e.PUESTO.Contains(searchString)
                                            || e.DEPENDENCIA.DEPENDENCIA_NOMBRE.Contains(searchString)
                                            || e.PERSONA.NOMBRE.Contains(searchString)
                                            || e.PERSONA.PRIMER_APELLIDO.Contains(searchString)
                                            || e.PERSONA.IDENTIFICACION.Equals(searchString)
                                            || e.SUPERVISOR.Contains(searchString)
                                            );
            }

            return View(empleados.ToList().ToPagedList(pageNumber, pageSize));



        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {

            ListaValoresPersona ListaPersona = new ListaValoresPersona();

            var ListaValoresPersona = ListaPersona.getListaPersona();
           
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE");
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION");
            ViewBag.PERSONA_ID = new SelectList(ListaValoresPersona, "PersonaId", "PersonaDescripcion");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLEADO_ID,PERSONA_ID,SUPERVISOR,DEPENDENCIA_ID,PUESTO,FECHA_INGRESO,SUELDO,BANCO,CUENTABANCARIA,EMPRESA,ESTATUS_ID")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOes.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", eMPLEADO.DEPENDENCIA_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION", eMPLEADO.ESTATUS_ID);
            ViewBag.PERSONA_ID = new SelectList(db.PERSONAs, "PERSONA_ID", "NOMBRE", eMPLEADO.PERSONA_ID);
            return View(eMPLEADO);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            ListaValoresPersona ListaPersona = new ListaValoresPersona();

            var ListaValoresPersona = ListaPersona.getListaPersona();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", eMPLEADO.DEPENDENCIA_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION", eMPLEADO.ESTATUS_ID);
            ViewBag.PERSONA_ID = new SelectList(ListaValoresPersona, "PersonaId", "PersonaDescripcion", eMPLEADO.PERSONA_ID);
            return View(eMPLEADO);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLEADO_ID,PERSONA_ID,SUPERVISOR,DEPENDENCIA_ID,PUESTO,FECHA_INGRESO,SUELDO,BANCO,CUENTABANCARIA,EMPRESA,ESTATUS_ID")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPENDENCIA_ID = new SelectList(db.DEPENDENCIAs, "DEPENDENCIA_ID", "DEPENDENCIA_NOMBRE", eMPLEADO.DEPENDENCIA_ID);
            ViewBag.ESTATUS_ID = new SelectList(db.ESTATUS.Where(e => e.TIPO == Bundle.ENTIDAD_GENERICA), "ESTATUS_ID", "DESCRIPCION", eMPLEADO.ESTATUS_ID);
            ViewBag.PERSONA_ID = new SelectList(db.PERSONAs, "PERSONA_ID", "NOMBRE", eMPLEADO.PERSONA_ID);
            return View(eMPLEADO);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            db.EMPLEADOes.Remove(eMPLEADO);
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
