using SportBlog.Data;
using SportBlog.Models;
using SportBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Implementation
{
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}