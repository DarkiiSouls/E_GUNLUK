using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_GUNLUK.Models
{
    public class UserFriendNotify
    {
        [Column(Order=1)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public FriendshipNotification Notification { get; set; }

        public bool IsRead { get; set; }


    }
    /*
    public class UserLikesNotify
    {
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public LikesNotification Notification { get; set; }

        public bool IsRead { get; set; }


    }
    */
    public class UserCommentsNotify
    {
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public CommentsNotifications Notification { get; set; }

        public bool IsRead { get; set; }


    }




}