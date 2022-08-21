using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace u21478377_H.W04.Controllers
{
    public class DonateInfo : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Donate");
        }

        //abstract class
        //inheritance no.2
        public abstract class Money
        {
            protected string _comment;
            protected int _amount;

            public Money(string comment, int amount)
            {
                _comment = comment;
                _amount = amount;
            }
            public abstract string DonationInfo();

        }

        //derived class
        //abstract method derived
        //polymorphism
        public class Guap : Money
        {
            protected string _email;

            public Guap(string email):base(comment, amount)
            {
                _email = email;
            }

            public static string comment { get; private set; }
            public static int amount { get; private set; }

            public override string DonationInfo()
            {
                return _comment ="Thank you for leaving a comment and donating";
            }
        }

    }
}
