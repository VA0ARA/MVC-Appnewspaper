using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using News.Models;
namespace News.DataAccess.Reposetory
{
    public class JornalistRepositrey : Reposetorty<Journalist> ,IJournalistRepositry
    {
        private ApplicationDbContext _db;
        public JornalistRepositrey(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Journalist obj)
        {
            _db.Journalists.Update(obj);
        }
    }
}
