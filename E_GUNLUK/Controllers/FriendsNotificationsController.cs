using E_GUNLUK.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data;
using System.Web;
namespace E_GUNLUK.Controllers
{
    public class FriendsNotificationsController : Controller
    {
        private ApplicationDbContext db;
        public FriendsNotificationsController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult ShowNotifications()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.GetUserId() != null)
                {
                    var userid = User.Identity.GetUserId();
                    var user = db.Users.Single(y => y.Id == userid);

                    var notifications = db.UserFriendNotify
                        .Include(J=>J.Notification)
                        .Include(y => y.Notification.friend)
                        .Include(n=>n.Notification.friend.user)
                        .ToList()
                        .Where(x => x.UserId == userid && !x.IsRead);
                    return View(notifications);
                }
            }
            else { return View(); }
            return View();
        }
        /*
        [HttpGet]

        public ActionResult SetAsRead(int? Id)
        {
            var d = Id;
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);

            if (Id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var notifyMeSinpai = db.userFriendNotify.Find(Id);
                //.Single(sinpai=>sinpai.NotificationId==Id);

            if (notifyMeSinpai == null)
            {
                return HttpNotFound();
            }
            else if (user != notifyMeSinpai.User)
            {
                return PartialView("~/Views/Notes/NotAuthorized.cshtml", null);
            }
            return View(notifyMeSinpai);
        }
        [Authorize]
        [HttpPost]
        public ActionResult SetAsRead(UserFriendNotify notification)
        {
            //var userid = User.Identity.GetUserId();
            //var user = db.Users.Single(u => u.Id == userid);

            var notifyMeSinpai = db.userFriendNotify.SingleOrDefault(t => t.NotificationId == notification.NotificationId);
            if (notifyMeSinpai!=null)
            {
                notifyMeSinpai.IsRead = true;
                notifyMeSinpai.UserId = notification.UserId;
                notifyMeSinpai.NotificationId = notification.NotificationId;
                notifyMeSinpai.User = db.Users.Single(x => x.Id == notification.UserId);
                
            }

            if (ModelState.IsValid)
            {
                db.Entry(notifyMeSinpai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
            //return View(notification);
        }
        */
    }
}
