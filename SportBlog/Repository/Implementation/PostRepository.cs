using SportBlog.Models;
using SportBlog.Repositories.Interfaces;
using SportBlog.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using SportBlog.Repositories.Implementation;

namespace SportBlog.Repositories.Implementation
{
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
                
        }

        public virtual IEnumerable<ExpandoObject> FindFromNCategory()
        {
            var tags = ApplicationDbContext.Tags.ToArray();
          
            var query = ApplicationDbContext.PostTags
                   .Select(i => new
                    {
                        Title = i.Post.Title,
                        Body = i.Post.Body,
                        CreationDate = string.Format("{0:dd/MM/yyyy}", i.Post.CreationDate),
                        CreatedBy = i.Post.CreatedBy,
                        Description = i.Tag.Description,
                       
                   });
            List<ExpandoObject> joinData = new List<ExpandoObject>();

            foreach (var item in query)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                joinData.Add(itemExpando as ExpandoObject);
            }

            return joinData;
          
        }

    }
}
