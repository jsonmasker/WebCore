using DataAccess.IRepositories;
using DataAccess.Repositories;
namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext context;
        private bool disposed = false;

        #region System
        public IUserRepository UserSystemRepository { get; private set; }
        public IUserTokenRepository UserTokenRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IRoleClaimRepository RoleClaimRepository { get; private set; }
        public IModuleRepository ModuleRepository { get; private set; }
        public IControllerRepository ControllerRepository { get; private set; }
        public IActionRepository ActionRepository { get; private set; }
        #endregion

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
            #region System
            UserSystemRepository = new UserRepository(context);
            UserTokenRepository = new UserTokenRepository(context);
            ModuleRepository = new ModuleRepository(context);
            RoleRepository = new RoleRepository(context);
            RoleClaimRepository = new RoleClaimRepository(context);
            ControllerRepository = new ControllerRepository(context);
            ActionRepository = new ActionRepository(context);
            #endregion

        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }
        public void Rollback()
        {
            throw new NotImplementedException();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
