using SportBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.ViewModel
{
    public class PostsPerUser
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
