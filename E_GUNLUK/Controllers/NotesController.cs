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
using System.Collections.Generic;
using System.Collections;

namespace E_GUNLUK.Controllers
{
    public class NotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // HOMEPAGE
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User!=null)
            {
                var userid = User.Identity.GetUserId();

                var user = db.Users.FirstOrDefault(u => u.Id == userid);
                var noteslist = db.notes
                    .Include(t=>t.Selected_tag)
                    .ToList()
                    .Where(n => n.NoteTaker == user);

                return View(noteslist);

            }
            return View();
        }

         // /Notes/Details/id
        public ActionResult Details(int? id)
        {

            Note note = db.notes
                .Include(u => u.NoteTaker)
                .SingleOrDefault(i => i.NoteId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (note == null)
            {
                return HttpNotFound();
            }
            ////List<Comments> commentlist = db.comments.ToList();
            
            //ViewBag.comments = commentlist;

            return View(note);
        }

        //  Notes/Create ** NEW NOTE **
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            //var tagz = db.tags.ToList();
            //var tagslist = new MultiSelectList(tagz, "tag", "tagId");
            //ViewBag.tagss = tagslist.ToList();
            NotesViewModel model = new NotesViewModel
            {
                tags_list = db.tags.ToList()
            };
            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(NotesViewModel viewModel)
        {

            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            var tag = db.tags.Single(t => t.tagId == viewModel.selected_tag);
            var note = new Note
            {
                NoteTaker = user,
                NoteDate = DateTime.Now,
                Title = viewModel.Title,
                NoteText = viewModel.NoteText,
                PubOrPvt = viewModel.PubOrPvt,
                Selected_tag = tag

            };
            db.notes.Add(note);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        /*
        public ActionResult Create(NotesViewModel viewModel)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);
            IList<Tags> _tags = new List<Tags>();
            foreach (var item in viewModel.selected_tags)
            {
                var the_selected_tags = db.tags.Single(t => t.tagId == item.tagId);
                _tags.Add(the_selected_tags);
            }
            var note = new Note {
                NoteTaker = user,
                NoteDate = DateTime.Now,
                Title = viewModel.Title,
                NoteText = viewModel.NoteText,
                PubOrPvt = viewModel.PubOrPvt,
                Selected_tags = _tags 
            };
            foreach (var i in _tags)
            {
                var ta = db.tags.Single(x => x.tagId == i.tagId);
                var _post_tag = new PostTag
                {
                    tagId = ta.tagId,
                    NoteId = note.NoteId
                };
                db.post_tag.Add(_post_tag);
                db.SaveChanges();

            }
            db.notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
        }*/

        //  Notes/Edit/id
        public ActionResult Edit(int? id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userid);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.notes.Find(id);
            //db.notes.FirstOrDefault(n=>n.NoteTaker.Id==user.Id);
            
            if (note == null)
            {
                return HttpNotFound();
            }
            else if(user!=note.NoteTaker)
            {
                return PartialView("~/Views/Notes/NotAuthorized.cshtml", null);
            }
            return View(note);
        }

        // POST: Notes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "NoteId,Title,NoteText,PubOrPvt")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
               db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/id
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

        // POST: Notes/Delete/id
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
