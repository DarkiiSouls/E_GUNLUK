using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class Tags
    {
        [Key]
        [Column(Order = 1)]
        public int tagId { get; set; }
        [ForeignKey("Note")]
        [Required]
        public int whichNote { get; set; }
        [Required]
        public string tag { get; set; }

        //to make equalities like tag.NoteId=model.note.id
        public virtual Note Note { get; set; }

    }
}