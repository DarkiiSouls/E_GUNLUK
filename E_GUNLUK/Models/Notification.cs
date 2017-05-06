using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class FriendshipNotification
    {
        public int Id { get; set; }
        public DateTime NotifyDate { get; set; }
        [Required]
        public FriendsList friend { get; set; }

    }
    /*
    public class LikesNotification
    {
        public int Id { get; set; }
        public DateTime NotifyDate { get; set; }
        [Required]
        [ForeignKey("like")]
        public int LikeId { get; set; }
        public Likes like { get; set; }


    }
    */
    public class CommentsNotifications
    {
        public int Id { get; set; }
        public DateTime NotifyDate { get; set; }
        [Required]
        public Comments Comment { get; set; }


    }

}