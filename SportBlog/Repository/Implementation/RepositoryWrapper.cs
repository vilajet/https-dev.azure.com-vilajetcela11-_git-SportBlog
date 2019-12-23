using SportBlog.Models;
using SportBlog.Repositories.Implementation;
using SportBlog.Repositories.Interfaces;
using SportBlog.Data;
using System;

namespace SportBlog.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private ApplicationDbContext _applicationDbContext;

        private IPostRepository _post;

        private IPostTagViewModelInterface _postCategory;

        private IPostsPerUser _postPerUser;

        private ITagsRepository _tags;

        private ICommentRepository _comments;

        private IPostTagRepository _postTags;

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_applicationDbContext);
                }
                return _post;
            }
        }


        public IPostTagViewModelInterface PostCategory
        {
            get
            {
                if (_postCategory == null)
                {
                    _postCategory = new PostTagViewModelRepository(_applicationDbContext);
                }
                return _postCategory;
            }
        }


        public IPostsPerUser PostPerUser
        {
            get
            {
                if (_postPerUser == null)
                {
                    _postPerUser = new PostPerUserRepository(_applicationDbContext);
                }
                return _postPerUser;
            }
        }

        public ITagsRepository Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new TagsRepository(_applicationDbContext);
                }
                return _tags;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_comments == null)
                {
                    _comments = new CommentRepository(_applicationDbContext);
                }
                return _comments;
            }
        }

        public IPostTagRepository PostTags
        {
            get
            {
                if (_postTags == null)
                {
                    _postTags = new PostTagRepository(_applicationDbContext);
                }
                return _postTags;
            }
        }
        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
