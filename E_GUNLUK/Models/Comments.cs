using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class Comments
    {
        [Key]
        [Column(Order = 1)]
        public int commentId { get; set; }
        [Required]
        public  ApplicationUser commentator { get; set; }
        [ForeignKey("Note")]
        [Required]
        public int whichNote { get; set; }
        [Required]
        public string theComment { get; set; }
        [Required]
        public DateTime commentDate { get; set; }

        //to match noteid with the note.noteId
        public virtual Note Note { get; set; }

    }
}