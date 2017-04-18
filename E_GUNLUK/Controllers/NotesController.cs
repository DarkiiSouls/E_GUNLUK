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
    public class NotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notes
        public ActionResult Index()
        {
            return View(db.notes.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            Note note = db.notes.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }
        [HttpGet]
        public ActionResult Comment(int noteid)
        {
            var newComment = new Comments();
            newComment.whichNote = noteid; // this will be sent from the ArticleDetails View, hold on :).

            return View(newComment);
        }
        [HttpPost]
        public ActionResult Comment(NotesCommentsViewModel viewModel,int noteid)
        {
            var userid = User.Identity.GetUserId();
            
            var user = db.Users.Single(u => u.Id == userid);
            var comment = new Comments
            {
                commentator = user,
                commentDate = DateTime.Now,
                theComment = viewModel.commentsviewmodel.theComment,
                whichNote = noteid
            };
            db.comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Notes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotesCommentsViewModel viewModel)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var note = new Note {
                NoteTaker = user,
                NoteDate = DateTime.Now,
                Title = viewModel.noteviewmodel.Title,
                NoteText = viewModel.noteviewmodel.NoteText,
                PubOrPvt = viewModel.noteviewmodel.PubOrPvt
            };
                db.notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteId,Title,NoteText,NoteDate,PubOrPvt")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.notes.Find(id);
            db.notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
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
