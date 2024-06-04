using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.NewFolder1;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Class1> list = new List<Class1>();
            var i = new Class1();
            i.name = "Test";
            i.age = 10;
            i.year = 10;
            list.Add(i);
           return View(list);
            List<Class1>list2 = new List<Class1>();
            var a = new Class1();
            a.name = "Anh";
            a.year = 10;
            a.age = 10;
            list2.Add(a);
            return View(list2);


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