
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportBlog.Models
{
    public class Tag
    {

        public Tag()
        {
            PostTags = new List<PostTag>();
        }

        public int TagId { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        [Required]
        public Boolean Enabled { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
