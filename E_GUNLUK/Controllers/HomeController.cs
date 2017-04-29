using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_GUNLUK.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var uid = User.Identity.GetUserId();
            //var user = db.Users.Single(u => u.Id == uid);
            var model = db.notes.ToList();
                //.Where(n=>n.NoteTaker.Id== user.Id || n.NoteTaker.Id != user.Id);
            
            return View(model);

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