using SportBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories
{
    public interface IRepositoryWrapper
    {
        IPostRepository Post { get; }
        IPostTagViewModelInterface PostCategory { get; }        
        IPostsPerUser PostPerUser { get; }
        ITagsRepository Tags { get; }
        ICommentRepository Comments { get; }
       IPostTagRepository PostTags { get; }
        void Save();
        void Dispose();
    }
}
