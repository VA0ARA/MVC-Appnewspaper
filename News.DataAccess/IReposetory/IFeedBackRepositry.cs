
using News.Models;
namespace News.DataAccess.IReposetory
{
   public interface IFeedBackRepositry : IRepository<FeedBack>
    {
        void Update(FeedBack obj);
    }
}
