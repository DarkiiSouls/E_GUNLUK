﻿using System;
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

    }
}