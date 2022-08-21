using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace u21478377_H.W04.Controllers
{
    public class Help : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("GetHelp");
        }

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

            public Client(int IDname) : base(name)
            {
                userID = IDname;
            }

            public static string name { get; private set; }

            public override string Info()
            {
                return base.Info() + "ID number:" + userID;
            }
        }
    }
}
