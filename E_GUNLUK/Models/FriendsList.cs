using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class FriendsList
    {
        [Key]
        [Column(Order = 1)]
        public int frindshipID { get; set; }
        public ApplicationUser user { get; set; }
        public ApplicationUser friend_user { get; set; }
    }

}