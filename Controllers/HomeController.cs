using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using u21478377_H.W04.Models;
using System.Web;

namespace u21478377_H.W04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //code to display narratives in view
            //get server first and get files from server path
            string path = Server.MapPath("~/Media/Required/");
            string[] req = Directory.GetFiles(path);
            ViewBag.reqs = req;


            return View();
        }
        //views for narratives
        public IActionResult GetHelp()
        {
            return View();
        }

        public IActionResult Resources()
        {
            return View();
        }
        public IActionResult Donate()
        {
            return View();
        }

        public IActionResult Apply()
        {
            return View();
        }

        //aadd code back here
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection frm)
        {

            //null checks
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (frm is null)
            {
                throw new ArgumentNullException(nameof(frm));
            }

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);


            System.IO.File.Delete(path);

            return RedirectToAction("Apply");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HttpPostedFileBase
    {

        public int ContentLength { get; internal set; }
        public ReadOnlySpan<char> FileName { get => fileName; internal set => fileName = value; }
        public ReadOnlySpan<char> fileName { get; private set; }

        internal void SaveAs(string path)
        {
            throw new NotImplementedException();
        }
    }

}
}
