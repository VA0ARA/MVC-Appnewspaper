using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using News.Models;
namespace News.DataAccess.Reposetory
{
    public class FeedBackRepositrey : Reposetorty<FeedBack> ,IFeedBackRepositry
    {
        private ApplicationDbContext _db;
        public FeedBackRepositrey(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(FeedBack obj)
        {
            _db.FeedBacks.Update(obj);
        }
    }
}
