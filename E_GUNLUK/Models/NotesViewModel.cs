using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_GUNLUK.Models
{
    public class NotesViewModel
    {
        public ApplicationUser NoteTaker { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
        public bool PubOrPvt { get; set; }
        //public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<Tags> tags_list { get; set; }
        // public IList<Tags> selected_tags { get; set; }
        public int selected_tag { get; set; }
        public NotesViewModel()
        {

        }

    }
}