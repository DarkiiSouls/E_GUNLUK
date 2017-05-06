using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace E_GUNLUK.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult FriendsFeed()
        {
            var userid = User.Identity.GetUserId();

            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var user = db.Users.Single(u => u.Id == userid);
            if (user == null)
            {
                return HttpNotFound();
            }
         
            var friendship = db.friendsList
                .Include(s => s.friend_user)
                .Include(q => q.user)
                .ToList()
                .Where(g => g.user.Id == userid);
            if (friendship == null)
            {
                return View();
            }
            var friends_posts = db.notes.Include(a=>a.Selected_tag).Include(m => m.NoteTaker).ToList();
            IList<Note> notes_friends = new List<Note>();
            foreach (var item in friendship)
            {
                notes_friends.Add(friends_posts.Single(a=>a.NoteTaker.Id == item.friend_user.Id)); 
            }
            if (friends_posts == null)
            {
                return View();
            }
            return View(notes_friends);
        }
        public ActionResult GetFirstNameLastName(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var user = db.Users.Find(id);
                return View(user);
            }
        }
        public ActionResult TopStories()
        {
            var notes = db.notes.ToList();
            var likes = db.likes.ToList();
            var top = (from n in notes
                       join l in likes
                       on n.NoteId equals l.whichNote into g
                       orderby g.Count() descending
                       select (n)
                               ).Take(5);
            return View(top);
        }
        public ActionResult Index()
        {
            var m = db.notes
                .Include(y=>y.NoteTaker)
                .Include(t => t.Selected_tag)
                .Where(x=>x.PubOrPvt==false);
            return View(m.ToList());
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
        public ActionResult ShowAllNotifications()
        {
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

} }