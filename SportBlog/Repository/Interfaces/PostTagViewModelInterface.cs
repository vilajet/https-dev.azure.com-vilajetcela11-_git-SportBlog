using SportBlog.Repositories;
using SportBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Interfaces
{
   public interface IPostTagViewModelInterface :IRepositoryBase<PostTagsViewModel>
    {
        IEnumerable<PostTagsViewModel> GetPostsForView(string titleSearch=null, string tag=null);
        PostTagsViewModel GetFullPost(int id);
    }
}
