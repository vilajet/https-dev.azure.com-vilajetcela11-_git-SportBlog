using SportBlog.Data;
using SportBlog.Repositories.Interfaces;
using SportBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlog.Repositories.Implementation
{
    public class PostTagViewModelRepository : RepositoryBase<PostTagsViewModel>, IPostTagViewModelInterface
    {
        public PostTagViewModelRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public PostTagsViewModel GetFullPost(int id)
        {
           return new PostTagsViewModel
            {
                post = (from posts in ApplicationDbContext.Posts 
                       where posts.PostId==id
                       select(posts)).SingleOrDefault(),
               
                tags = (from itempost in ApplicationDbContext.Posts
                        join tagItemposts in ApplicationDbContext.PostTags on
                        itempost.PostId equals tagItemposts.PostId
                        join tagitem in ApplicationDbContext.Tags
                        on tagItemposts.TagId equals tagitem.TagId
                        where(tagItemposts.PostId==id)
                        select (tagitem)),

               comments = (from post in ApplicationDbContext.Posts
                           join comments in ApplicationDbContext.Comments on
                           post.PostId equals comments.PostId
                           select (comments))
                           .Where(i=>i.PostId==id),
           };
        }

        public IEnumerable<PostTagsViewModel> GetPostsForView(string titleSearch=null, string tag =null)
        {
           var listOfPostTag = new List<PostTagsViewModel>();
           foreach(var post in ApplicationDbContext.Posts)
            {

                var postTagElement = new PostTagsViewModel
                {
                    post = post,
                    tags = (from itempost in ApplicationDbContext.Posts
                            join tagItemposts in ApplicationDbContext.PostTags on
                            post.PostId equals tagItemposts.PostId
                            join tagitem in ApplicationDbContext.Tags
                            on tagItemposts.TagId equals tagitem.TagId
                            select (tagitem)).Distinct(),
                };
                if (!string.IsNullOrWhiteSpace(titleSearch) || !string.IsNullOrWhiteSpace(tag))
                {
                    foreach (var tagItem in postTagElement.tags)
                    {
                        if ((!string.IsNullOrWhiteSpace(titleSearch) && postTagElement.post.Title.ToLower().Contains(titleSearch.ToLower())) ||
                            (!string.IsNullOrWhiteSpace(tag) && (string.Compare(tagItem.Description, tag) == 0)))
                        {
                            listOfPostTag.Add(postTagElement);
                        }
                    }
                }
                else
                {
                    listOfPostTag.Add(postTagElement);
                }
               
            }
           
            return listOfPostTag.Distinct();
        }
    }
}
