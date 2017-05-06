using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class Likes
    {
        public  ApplicationUser user { get; set; }
        [Key]
        [ForeignKey("Note")]
        [Required]
        public int whichNote { get; set; }
        //to match noteId with note.noteId
        public virtual Note Note { get; set; }

    }
}