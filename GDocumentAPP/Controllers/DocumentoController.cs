using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDocumentAPP.Models;
using GDocumentAPP.Context;
using System.Configuration;
using GDocumentAPP.Services;
using System.IO;

namespace GDocumentAPP.Controllers
{
    public class DocumentoController : Controller
    {
        private GDocumentDBEntities db = new GDocumentDBEntities();
        
        public string pathTarifarioImage = ConfigurationManager.AppSettings["pathTarifarioImage"].ToString();
        public string pathTarifarioXml = ConfigurationManager.AppSettings["pathTarifarioXML"].ToString();
        public string pathDocumentoRepositorio = ConfigurationManager.AppSettings["pathDocumentoRepositorio"].ToString();
               
        // GET: Documento
        public ActionResult Index(string searchString, string EMPLEADO_ID)
        {

            ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR");

            bool hayDatoEnEmpleadoId = String.IsNullOrEmpty(EMPLEADO_ID) ? false : true;
      
            var documentos = from d in db.DOCUMENTOes.Include(d => d.EMPLEADO).Include(d => d.ESTATU).Include(d => d.USUARIO)
                             select d;

            if (hayDatoEnEmpleadoId)
            {
                int empleadoId = int.Parse(EMPLEADO_ID);
                documentos = documentos.Where(d => d.EMPLEADO_ID.Equals(empleadoId));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                documentos = documentos.Where(d => d.NOMBRE_DOCUMENTO.Contains(searchString)
                                            || d.CANAL_GENERACION.Contains(searchString)
                                            );
            }

            return View(documentos.ToList());

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

       // [HttpPost]
        public ActionResult GuardarArchivoCargado()
        {


            List<int> listValues = new List<int>();
            Request.Params.AllKeys
                .Where(n => n.StartsWith("EmpleadoId"))
                .ToList()
                .ForEach(x => listValues.Add(int.Parse(Request.Params[x])));

            bool isSavedSuccessfully = true;
            string fName = "";

            HandlePathFile handlePathDirectory = new HandlePathFile();
          
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                fName = file.FileName;

                var contentType = file.ContentType;

                if (file != null && file.ContentLength > 0)
                {
                    HandlerBackupFile(@pathDocumentoRepositorio, fName);

                    bool isExists = System.IO.Directory.Exists(@pathDocumentoRepositorio);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(@pathDocumentoRepositorio);

                  //  ViewBag.EMPLEADO_ID = new SelectList(db.EMPLEADOes, "EMPLEADO_ID", "SUPERVISOR");

                    DOCUMENTO documento = new DOCUMENTO();
                    documento.EMPLEADO_ID = listValues.First();
                    documento.NOMBRE_DOCUMENTO = file.FileName;
                    documento.EXTENSION = @pathDocumentoRepositorio;
                    documento.ESTATUS_ID = 1;
                    documento.FECHA_CREACION = DateTime.Now;
                    documento.CANAL_GENERACION = "DropZoneFileUpload";
                    documento.USUARIO_ID = 1;
                    documento.SIZE = file.ContentLength;


                    SaveFileInRepositorio(file, pathDocumentoRepositorio);

                    if (ModelState.IsValid)
                    {
                        db.DOCUMENTOes.Add(documento);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            ActionResult JsonResult = getJsonResult(isSavedSuccessfully, fName);
           
            return JsonResult;

        }

        private void SaveFileInRepositorio(HttpPostedFileBase file, string pathDocumento)
        {
            var pathDocumentoRepositorio = string.Format("{0}\\{1}", @pathDocumento, file.FileName);
            file.SaveAs(pathDocumentoRepositorio);
            CopiarFileEnCarpetaProyecto(file.FileName, pathDocumento);

        }

        private static void CopiarFileEnCarpetaProyecto(string fileName, string pathDocumento)
        {
            string directoryImageConfig = ConfigurationManager.AppSettings["directoryImage"].ToString();

            var pathDocumentoSource = System.IO.Path.Combine(pathDocumento, fileName);

            var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            var directoryImage = new DirectoryInfo(string.Format("{0}" + directoryImageConfig, currentDirectory.ToString()));

            string pathDocumentoTarget = System.IO.Path.Combine(directoryImage.ToString(), fileName);

            System.IO.File.Copy(pathDocumentoSource, pathDocumentoTarget, true);
        }

        private ActionResult getJsonResult(bool isSavedSuccessfully, string fName)
        {
            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error Guardado el Archivo" });
            }
        }

        private static void HandlerBackupFile(string sourcePath, string fileName)
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

            bool isExistsSourceFile = System.IO.File.Exists(sourceFile);

            if (isExistsSourceFile)
            {
                HandlePathFile handlePathFileBackup = new HandlePathFile();
                string pathBackup = handlePathFileBackup.GenerateFolderBackup(sourcePath);

                string destFileBackup = System.IO.Path.Combine(pathBackup, fileName);

                System.IO.File.Copy(sourceFile, destFileBackup, true);

            }
        }

    

        public ActionResult ObtenerDocumentos(string empleadoId, string search)
        {

            string imagePath = ConfigurationManager.AppSettings["pathServerImage"].ToString();
            List<DOCUMENTO> documentoList = new List<DOCUMENTO>();
            int IdEmpleado = 0;

            bool hayDatoEnEmpleadoId = String.IsNullOrEmpty(empleadoId) ? false : true;
            bool hayDatoEnSearch = String.IsNullOrEmpty(search) ? false : true;

            if (hayDatoEnEmpleadoId)
                IdEmpleado = int.Parse(empleadoId);

            var documentos = db.DOCUMENTOes.Include(d => d.EMPLEADO).Include(d => d.ESTATU).Include(d => d.USUARIO);

            if (hayDatoEnEmpleadoId)
            {
                documentos = documentos.Where(d => d.EMPLEADO_ID.Equals(IdEmpleado));
            }

            if (hayDatoEnSearch)
            {
                documentos = documentos.Where(d => d.NOMBRE_DOCUMENTO.Contains(search)
                                            || d.CANAL_GENERACION.Contains(search)
                                            );
            }
                      
            documentoList = documentos.ToList();

            var ListaDocumento = documentoList.Select(D => new
            {
                DocumentoId = D.DOCUMENTO_ID,
                DocumentoNombre = D.NOMBRE_DOCUMENTO,
                DocumentoSize = D.SIZE,
                DocumentoRuta = imagePath
            });

            return Json(new { Data = ListaDocumento }, JsonRequestBehavior.AllowGet);
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
