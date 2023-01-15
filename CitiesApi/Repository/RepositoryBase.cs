using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CitiesApi.Models.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDBContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationDBContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext; 
        }
        public void Create(T entity)
        {
           this.RepositoryContext.Set<T>().Add(entity);
           this.RepositoryContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.RepositoryContext.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindbyCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

       
    }
    
 }

