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
    public class RolController : Controller
    {
        private ModelDocumentoApp db = new ModelDocumentoApp();

        // GET: Rol
        public ActionResult Index(int? page, string searchString)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var rol = from s in db.ROLs
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                rol = rol.Where(s => s.DESCRIPCION.Contains(searchString));
            }

            return View(rol.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROLs.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROL_ID,DESCRIPCION")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.ROLs.Add(rOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOL);
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROLs.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: Rol/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROL_ID,DESCRIPCION")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOL);
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROLs.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROL rOL = db.ROLs.Find(id);
            db.ROLs.Remove(rOL);
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
