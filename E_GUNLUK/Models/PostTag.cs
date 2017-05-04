using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int PtId { get; set; }
        [Required]       
        [ForeignKey("tag")]
        public int tagId { get; set; }
        
        [Required]
        [ForeignKey("note")]
        public int NoteId { get; set; }

        public virtual Note note { get; set; }
        public virtual Tags tag { get; set; }

    }
}