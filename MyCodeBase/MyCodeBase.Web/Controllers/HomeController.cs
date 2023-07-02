using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCodeBase.Web.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            logger.Trace("**** Trace *** ");
            logger.Debug("**** Debug ***");
            logger.Info("**** Info ***");
            logger.Warn("**** Warn ***");
            logger.Error("**** Error ***");
            logger.Fatal("**** Fatal ***");
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
    }
}