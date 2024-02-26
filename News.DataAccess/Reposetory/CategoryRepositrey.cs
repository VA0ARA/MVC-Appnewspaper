using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using News.Models;
namespace News.DataAccess.Reposetory
{
    public class CategoryRepositrey :Reposetorty<Category> ,IcategoryRepositry
    {
        private ApplicationDbContext _db;
        public CategoryRepositrey(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
