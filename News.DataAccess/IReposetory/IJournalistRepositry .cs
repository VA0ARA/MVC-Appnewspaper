
using News.Models;
namespace News.DataAccess.IReposetory
{
   public interface IJournalistRepositry : IRepository<Journalist>
    {
        void Update(Journalist obj);
    }
}
