using DataAccess.IRepositories;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {

        #region System
        IUserRepository UserSystemRepository { get; }
        IUserTokenRepository UserTokenRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRoleClaimRepository RoleClaimRepository { get; }
        IControllerRepository ControllerRepository { get; }
        IActionRepository ActionRepository { get; }
        #endregion

        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
