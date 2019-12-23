using SportBlog.Data;
using SportBlog.Repositories.Interfaces;
using SportBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Implementation
{
    public class PostViewControllerRepository : RepositoryBase<PostsViewModel>, IPostViewControllerRepository
    {
        public PostViewControllerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

    }
}
