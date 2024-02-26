

namespace News.DataAccess.IReposetory
{
    public interface IUnitOfWork
    {
        IIncidentRepositry incident { get; }
        IcategoryRepositry Category { get; }
        IJournalistRepositry jornalist { get; }
        IAdminRepositry admin { get; }
        void Save();
    }
}
