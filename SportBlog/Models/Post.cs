using SportBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportBlog.Models
{
    public class Post
    {

        public Post()
        {
            PostTags = new List<PostTag>();
            Comments = new List<Comment>();
         //   File = new File();
        }

        public int PostId { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Body { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public String CreatedBy { get; set; }
       
        //[Column(TypeName = "image")]
        public string PostImage { get; set; }
        [Required]
        public Boolean Enabled { get; set; }
        [Required]
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

       // public virtual File File { get; set; }

        public string UserId { get; set; }
       
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
