using Microsoft.EntityFrameworkCore;
using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using System.Linq.Expressions;
namespace News.DataAccess.Reposetory
{
    public  class Reposetorty <T>: IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbset;
        public Reposetorty(ApplicationDbContext db)
        {
            _db = db;
            this.dbset=_db.Set<T>();
        }
        public void Add(T entity)
        {
           dbset.Add(entity);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            var obj=query.Where(filter).FirstOrDefault();
            return obj;
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }
        public void Remove(T entity)
        {
            dbset.Remove(entity);   
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
        //save & update >>EF core
    }
}
