using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CheckBoxTest.Models;

namespace CheckBoxTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            TestEntityModel db = new TestEntityModel();
            return View(db.User);
        }
        
        [HttpPost]
        public string Index(IEnumerable<User> users)
        {
            if(users.Count(x => x.presente) == 0)
            {
                return "You didn't select any city";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - ");
                foreach(User user in users)
                {
                    if(user.presente)
                    {
                        sb.Append(user.FirstName + ", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
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