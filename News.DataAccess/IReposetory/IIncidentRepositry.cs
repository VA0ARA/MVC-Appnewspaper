using News.Models;
namespace News.DataAccess.IReposetory
{
   public interface IIncidentRepositry:IRepository<Incident>
    {
        void Update(Incident obj);
    }
}
