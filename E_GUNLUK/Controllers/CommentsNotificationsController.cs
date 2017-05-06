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
    public class CommentsNotificationsController : Controller
    {
        private ApplicationDbContext db;
        public CommentsNotificationsController()
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


                    var notifications = db.UserCommentsNotify
                        .Include(y => y.Notification.Comment.commentator)
                        .ToList()
                        .Where(x => x.UserId == userid && !x.IsRead);
                    return View(notifications);
                }
            }
            else { return View(); }
            return View();
        }
    }
}