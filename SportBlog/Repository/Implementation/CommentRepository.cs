using SportBlog.Data;
using SportBlog.Models;
using SportBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Implementation
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

    }
}
