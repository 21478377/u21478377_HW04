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
            string path = Server("~/Media/Required/");
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

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, FormCollection frm)
        {
            
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
}
