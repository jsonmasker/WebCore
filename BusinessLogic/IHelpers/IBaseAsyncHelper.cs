using Common.Models;
using DocumentFormat.OpenXml.Wordprocessing;

namespace BusinessLogic.IHelpers
{
    public interface IBaseAsyncHelper<T> where T : class
    {
        public Task<Pagination<T>> GetAllAsync(int pageIndex, int pageSize);
        public Task<T> GetByIdAsync(int id);
        public Task<bool> CreateAsync(T model);
        public Task<bool> UpdateAsync(T model);
        public Task<bool> SoftDeleteAsync(int id);
        public Task<bool> RestoreAsync(int id);
        public Task<bool> DeleteAsync(int id);
    }
}
