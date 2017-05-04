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
        [Required]
        public string tag { get; set; }

        public IList<Note> Notes { get; set; }

    }
}