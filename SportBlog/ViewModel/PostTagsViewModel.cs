using SportBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.ViewModel
{
    public class PostTagsViewModel
    {
        public ApplicationUser applicationUser;
        public PostTag postTag;
        public Post post;
        public IEnumerable<Tag> tags;
        public IEnumerable<Comment> comments;
       
    }
}
