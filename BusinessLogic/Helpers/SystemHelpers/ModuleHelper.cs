using AutoMapper;
using BusinessLogic.IHelpers.ISystemHelpers;
using Common.ViewModels.SystemViewModels;
using DataAccess;
using DataAccess.DTOs;

namespace BusinessLogic.Helpers.SystemHelpers
{
    public class ModuleHelper : IModuleHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ModuleHelper(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ModuleViewModel model)
        {
            try
            {
                ModuleDTO data = _mapper.Map<ModuleDTO>(model);
                await _unitOfWork.ModuleRepository.CreateAsync(data);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<IEnumerable<ModuleViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ModuleViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ModuleViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
