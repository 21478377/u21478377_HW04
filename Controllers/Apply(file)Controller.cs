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
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            List<Models.KISMET> files = new List<KISMET>();
            foreach (string filePath in filePaths)
            {
                files.Add(new KISMET
                {
                    FileName = Path.GetFileName(filePath)
                });
            }
            return View(files);
            return RedirectToAction("Apply");

            return RedirectToAction("Apply");
        }

        //if want to delete file and reupload
        public ActionResult DeleteFile(string fileName)
        {
            //add code back here
            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);


            System.IO.File.Delete(path);

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

        //save details 
        //OOP 
        //poly
        //public details

        class Person
        {
            private string cname = "";
            public string firstName { get { return cname; } }

            private string csurname = "";
            public string Surname { get { return csurname; } }

            private int cnumber =Convert.ToInt32( "");
            public int Cell { get { return cnumber; } }

            private string cemail = "";
            public string Email { get { return cemail; } }

            public int cadd { get; set; }

            public int add
            {
                get
                {
                    return cadd;
                }
                set
                {
                    cadd = value;
                }
            }
            //constructor
            /// <summary>
            /// (   Reminder: 3 // signs to include below parameter reminders
            public Person(string firstName, string Surname)
            {

                /// <param name="firstName">name</param>
                /// <param name="Surname">surname</param>
                cname = firstName;
                csurname = Surname;
            }
            
        }

    }
}
