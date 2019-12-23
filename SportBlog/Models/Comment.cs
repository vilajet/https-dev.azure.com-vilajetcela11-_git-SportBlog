using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public String Message { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        [Required]
        public Boolean Enabled { get; set; }

        public int PostId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
