
using News.Models;
namespace News.DataAccess.IReposetory
{
   public interface IAdminRepositry : IRepository<Admin>
    {
        void Update(Admin obj);
    }
}
