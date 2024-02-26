using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using News.Models;
namespace News.DataAccess.Reposetory
{
    public class AdminRepositrey : Reposetorty<Admin> ,IAdminRepositry
    {
        private ApplicationDbContext _db;
        public AdminRepositrey(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Admin obj)
        {
            _db.Admins.Update(obj);
        }
    }
}
