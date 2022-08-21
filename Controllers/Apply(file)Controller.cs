using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using u21478377_H.W04.Models;

namespace u21478377_H.W04.Controllers
{
    public class Apply_file_Controller : Controller
    {
        public IActionResult Index()
        {
            //add code back here
            return RedirectToAction("Apply");
        }

        //if want to delete file and reupload
        public ActionResult DeleteFile(string fileName)
        {
            //add code back here
            return RedirectToAction("Apply");
        }
        //polymorphism
        //inherited classes 
        //base class
        //virtual class method
        public class User
        {
            protected string Name;

            public User(string name)
            {
                Name = name;
            }
            //virtual method
            public virtual string Info()
            {
                return Name;
            }
        }

        //derived class
        public class Client : User
        {
            protected int userID;

            public Client(int IDname):base(name)
            {
                userID = IDname;
            }

            public static string name { get; private set; }

            public override string Info()
            {
                return base.Info()+"ID number:"+userID;
            }
        }



    }
}
