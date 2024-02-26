using News.DataAccess.Data;
using News.DataAccess.IReposetory;
using News.Models;
namespace News.DataAccess.Reposetory
{
    public class IncidentRepositrey :Reposetorty<Incident> , IIncidentRepositry
    {
        private ApplicationDbContext _db;
        public IncidentRepositrey(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Incident obj)
        {
            _db.Incidents.Update(obj);
        }


    }
}
