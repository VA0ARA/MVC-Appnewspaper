
using News.DataAccess.Data;
using News.DataAccess.IReposetory;
namespace News.DataAccess.Reposetory
{
    public class UnitOfwork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IcategoryRepositry Category { get; private set; }
        public IJournalistRepositry jornalist { get; private set; }
        public IIncidentRepositry incident { get; private set; }
        public IAdminRepositry admin { get; private set; }
        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepositrey(_db);
            jornalist = new JornalistRepositrey(_db);
            incident = new IncidentRepositrey(_db);
            admin = new AdminRepositrey(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
