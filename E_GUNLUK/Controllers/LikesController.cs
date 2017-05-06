using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var user = db.Users.Single(u => u.Id == userid);

            
            var the_like = db.likes.SingleOrDefault(l => l.whichNote == id && l.user.Id==user.Id);
            ViewBag.stat = "Like";
            if (the_like == null || the_like.user!=user)
            {
                ViewBag.stat = "Like";
            }
            else if (the_like != null || the_like.user == user)
            {
                ViewBag.stat = "dislike";

            }
            }
            return View();
        }

        [HttpPost] //POST
        [Authorize]
        [ValidateAntiForgeryToken]
        
        public ActionResult Like(Likes like, int id)
        {
            ViewBag.stat = "Like";
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var checker_like = db.likes.SingleOrDefault(l => l.whichNote == id && l.user.Id == userid);
            var like_var = new Likes {
                user = user,
                whichNote = id
            };
            if (checker_like == null)
            {
                //ViewBag.stat = "Like";
                db.likes.Add(like_var);       
                db.SaveChanges();
                return RedirectToAction("Details","Notes", new { id = id });
            }
            else if(checker_like !=null)
            {
                //ViewBag.stat = "dislike";
                db.likes.Remove(checker_like);
                db.SaveChanges();
                return RedirectToAction("Details", "Notes", new { id= id });

            }
            return View();
        }
        public ActionResult LikesCounts(int id)
        {
            var Likeslist = db.likes.Where(m => m.whichNote == id).ToList();
            return View(Likeslist);
        }

    }
}