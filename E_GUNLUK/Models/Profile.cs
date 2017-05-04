using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class Profile
    {
        [Key]
        public string User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Birthdate { get; set; }
        public string Bio { get; set; }

    }
}