using SportBlog.Models;
using SportBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SportBlog.Repositories;

namespace SportBlog.Repositories.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.ApplicationDbContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.ApplicationDbContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDbContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.ApplicationDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
        }

       

    }
}
