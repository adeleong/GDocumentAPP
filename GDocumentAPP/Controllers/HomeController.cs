using GDocumentAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GDocumentAPP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ObtenerDocumentoEstatus()
        {

            DashboardViewModels DataDonut = new DashboardViewModels();

            IQueryable DataDonutHome = DataDonut.getDataDonut();

            return Json(new { Data = DataDonutHome }, JsonRequestBehavior.AllowGet);
        }

    }
}