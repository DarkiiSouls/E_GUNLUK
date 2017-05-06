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
    public class ProfilesController : Controller
    {
    

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult FetchPosts(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var notes = db.notes.Include(d=>d.NoteTaker).ToList().Where(t => t.NoteTaker.Id == id);

            if (notes == null)
            {
                return HttpNotFound();
            }
            return View(notes);
        }


        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            //db.notes.FirstOrDefault(n=>n.NoteTaker.Id==user.Id);

            if (profile == null)
            {
                return HttpNotFound();
            }
            else if (user != db.Users.Find(profile.User))
            {
                return PartialView("~/Views/Notes/NotAuthorized.cshtml", null);
            }
            return View(profile);
        }

        // POST: Notes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User,FirstName,LastName,Birthdate,Bio")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","Profiles", new { id = profile.User });
            }
            return View(profile);
        }
        [HttpGet]
        public ActionResult AddFriend(string id)
        {
            var userid = User.Identity.GetUserId();
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var user = db.Users.Single(u => u.Id == userid);
            //db.notes.FirstOrDefault(n=>n.NoteTaker.Id==user.Id);

            if (user == null)
            {
                return View();
            }

            var friendship = db.friendsList.SingleOrDefault(f => f.friend_user.Id == id && f.user.Id ==userid);         
            if (db.friendsList.SingleOrDefault(f => f.friend_user.Id == id && f.user.Id == userid) == null )
                {
                ViewBag.stat = "Friend";
                }
           else if (friendship != null || friendship.user!=null)
                {
                ViewBag.stat = "Unfriend";

                }
            
            return View();
        }
        [HttpPost] //POST
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddFriend(FriendsList frnd,string id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var friendship = db.friendsList.SingleOrDefault(f => f.friend_user.Id == id && f.user.Id == userid);

            var friend_request = new FriendsList
            {
                friend_user = db.Users.Find(id),
                user = user
            };
            if (db.friendsList.SingleOrDefault(f => f.friend_user.Id == id && f.user.Id == userid) == null)
            {
                var notification = new FriendshipNotification
                {
                    NotifyDate = DateTime.Now,
                    friend = friend_request
                };
                var msg_receiver = db.Users.Single(m => m.Id == friend_request.friend_user.Id);
                var userFrndNot = new UserFriendNotify
                {
                    Notification = notification,
                    User = msg_receiver,
                    
                };
                db.UserFriendNotify.Add(userFrndNot);
                db.friendsList.Add(friend_request);
                db.SaveChanges();
                return RedirectToAction("Details", "Profiles", new { id = id });
            }
            else if (db.friendsList.SingleOrDefault(f => f.friend_user.Id == id && f.user.Id == userid) != null)
            {
                db.friendsList.Remove(friendship);
                db.SaveChanges();
                return RedirectToAction("Details", "Profiles", new { id = id });

            }
            return View();
        }
        [Authorize]
        public ActionResult ShowFriendsList()
        {
            var userid = User.Identity.GetUserId();
            var U = db.Users.Single(u=>u.Id == userid);
            var friendslist = db.friendsList.Include(r=>r.friend_user).ToList().Where(x=>x.user == U && x.friend_user.Id !=userid);
            return View(friendslist);
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
