using SportBlog.Data;
using SportBlog.Models;
using SportBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Implementation
{
    public class TagsRepository : RepositoryBase<Tag>, ITagsRepository
    {
        public TagsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
