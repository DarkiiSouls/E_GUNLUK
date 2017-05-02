using E_GUNLUK.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace E_GUNLUK.Controllers
{
    public class TagsController : Controller
    {
        private ApplicationDbContext db;
        public TagsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Tags
        public ActionResult Index()
        {

          
                return View(db.tags.ToList());
            
        }
        public ActionResult ShowTags(int id)
        {
            //var tagslist = db.tags.Where(t => t.whichNote == id);
            var tags = db.tags.Select(c => new {
                tag = c.tag,
                tagId = c.tagId
            }).ToList();
            ViewBag.tags = new MultiSelectList(tags, "tagId", "Tag");

            return View();
        }
        
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tags t)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var tag = new Tags
            {
                tag = t.tag,            
            };
            db.tags.Add(tag);
            db.SaveChanges();
            return RedirectToAction("Index","Tags");

        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tags tag = db.tags.Find(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tags tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }



        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tags/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
