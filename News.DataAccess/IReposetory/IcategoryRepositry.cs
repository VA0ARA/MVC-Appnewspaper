
using News.Models;
namespace News.DataAccess.IReposetory
{
   public interface IcategoryRepositry:IRepository<Category>
    {
        void Update(Category obj);
    }
}
