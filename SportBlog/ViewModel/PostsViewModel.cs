using SportBlog.Data;
using SportBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.ViewModel
{
    public class PostsViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Enabled { get; set; }
        public string UserId { get; set; }
        public string PostImage { get; set; }
      
        public IEnumerable<int> TagsId{ get; set; }

        public List<Tag> Tags { get; set; }       
    
    }
}
