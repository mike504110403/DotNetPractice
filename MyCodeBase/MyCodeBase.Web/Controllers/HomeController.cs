using MyCodeBase.Library.ViewModels.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Aspose.Words;
using MyCodeBase.Library.Extensions;
using Aspose.Words.Reporting;

namespace MyCodeBase.Web.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            //logger.Trace("**** Trace *** ");
            //logger.Debug("**** Debug ***");
            //logger.Info("**** Info ***");
            //logger.Warn("**** Warn ***");
            //logger.Error("**** Error ***");
            //logger.Fatal("**** Fatal ***");
            return View();
        }
        /// <summary>
        /// 取得doc檔匯出串流
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportDocxFile()
        {
            var t = 0;
            var testLists = new List<TestList>();
            while (t < 10)
            {
                var testlist = new TestList()
                {
                    Subject = "test",
                    Score = 100
                };
                testLists.Add(testlist);
                t += 1;
            }
            var data = new Test()
            {
                Name = "HHH",
                Age = 26,
                TestLists = testLists
            };
            // 開啟範例文檔
            var doc = new Document("D:\\MyPractice\\DotNetPractice\\MyCodeBase\\MyCodeBase.Console\\Temp\\test.docx");
            doc.BindData(data);
            doc.Save("bindedDoc.docx", SaveFormat.Docx);
            return File(doc.GetFileStream(SaveFormat.Docx), "application/docx");
        }
    }
}