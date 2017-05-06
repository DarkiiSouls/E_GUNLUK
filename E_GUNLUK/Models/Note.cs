using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_GUNLUK.Models
{
    public class Note
    {
        
        public  ApplicationUser NoteTaker { get; set; }
        [Key]
        [Column(Order = 1)]
        public int NoteId { get; set; }
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        public string NoteText { get; set; }
        [Required]
        public DateTime NoteDate { get; set; }
        [Required]
        public bool PubOrPvt { get; set; }
        public Tags Selected_tag { get; set; }

        //[ForeignKey("tags")]
        //public IEnumerable<Tags> selected_tags { get; set; }

    }
}