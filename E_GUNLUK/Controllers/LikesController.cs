using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_GUNLUK.Controllers
{
    public class LikesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        // Create Comment ( Partial View )
        [HttpGet] //GET
        public ActionResult Like(int id)
        {
            return View();
        }

        [HttpPost] //POST
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Like(Likes like, int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var checker_like = db.likes.SingleOrDefault(l => l.whichNote == id && l.user.Id == userid);
            var like_var = new Likes {
                user = user,
                whichNote = id
            };
            if (checker_like == null)
            { 
                db.likes.Add(like_var);
                db.SaveChanges();
                return View(like_var);
            }
            else
            {

            }
            return View();
        }

    }
}