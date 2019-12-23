using SportBlog.Models;
using SportBlog.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Interfaces
{
    public interface IPostRepository : IRepositoryBase<Post> 
    {

     IEnumerable<ExpandoObject> FindFromNCategory();
    }
}
