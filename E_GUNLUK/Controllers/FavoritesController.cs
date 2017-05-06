using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;

namespace E_GUNLUK.Controllers
{
    public class FavoritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult FavList()
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var fav_list = db.favorites.Include(n=>n.Note).ToList().Where(f => f.user == user).ToList();
            return View(fav_list);
        }
        [HttpGet]
        public ActionResult AddToFav(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);

            ViewBag.favStat = "Fav";
            var check_fav = db.favorites.SingleOrDefault(f=>f.user.Id == userid && f.whichNote==id);
           
                if (check_fav == null || check_fav.user != user)
                {
                    ViewBag.favStat = "Fav";
                }
                else if (check_fav!=null || check_fav.user == user)
                {
                    ViewBag.favStat = "Unfav";

                }

            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddToFav(Favorites fav,int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var check_fav = db.favorites.SingleOrDefault(l => l.whichNote == id && l.user.Id == userid);
            var fav_var = new Favorites
            {
                user = user,
                whichNote = id
            };
            if (check_fav == null)
            {
               
                db.favorites.Add(fav_var);
                db.SaveChanges();
                return RedirectToAction("Details", "Notes", new { id = id });
            }
            else if (check_fav != null)
            {
                db.favorites.Remove(check_fav);
                db.SaveChanges();
                return RedirectToAction("Details", "Notes", new { id = id });

            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
