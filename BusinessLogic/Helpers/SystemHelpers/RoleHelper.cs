using AutoMapper;
using BusinessLogic.IHelpers.ISystemHelpers;
using Common.Models;
using Common.ViewModels.SystemViewModels;
using DataAccess;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BusinessLogic.Helpers.SystemHelpers
{
    public class RoleHelper : IRoleHelper
    {
        private readonly RoleManager<RoleDTO> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RoleHelper(RoleManager<RoleDTO> roleManager,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(RoleViewModel model)
        {
            var role = new RoleDTO
            {
                Name = model.Name,
                Description = model.Description,
                NormalizedName = model.Name.ToUpper(),
                IsActive = model.IsActive,
                //CreatedBy = _userInformation.GetUserName(),
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                foreach (var item in model.SelectedRoleClaims)
                {
                    RoleClaimDTO selectedRoleClaim = new RoleClaimDTO() { Id = 0, RoleId = role.Id, RoleClaimId = item.RoleClaimId, RoleClaimGroupId = item.RoleClaimGroupId };
                    var roleClaim = await _unitOfWork.ActionRepository.GetByIdAsync(item.RoleClaimId);
                    var roleClaimGroup = await _unitOfWork.ControllerRepository.GetByIdAsync(item.RoleClaimGroupId);
                    if (roleClaim != null && roleClaimGroup != null)
                    {
                        selectedRoleClaim.ClaimType = roleClaimGroup.Name.Trim() + "_" + roleClaim.Name.Trim();
                        selectedRoleClaim.ClaimValue = roleClaimGroup.Name.Trim() + "_" + roleClaim.Name.Trim();
                        await _unitOfWork.RoleClaimRepository.CreateAsync(selectedRoleClaim);
                    }
                }
                await _unitOfWork.SaveChangesAsync();
            }
            return result.Succeeded;
        }

        public async Task<Pagination<RoleViewModel>> GetAllAsync(int pageIndex, int pageSize)
        {
            Pagination<RoleViewModel> model = new Pagination<RoleViewModel>();
            if(pageSize < 0)
                pageSize = model.PageSize;
            IEnumerable<RoleDTO> data = await _unitOfWork.RoleRepository.
                GetAllAsync(filter: s => s.IsActive && !s.IsDeleted);
            model.TotalItems = data.Count();
            model.CurrentPage = pageIndex;
            model.TotalPages = (int)Math.Ceiling(model.TotalItems / (double)pageSize);

            data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            model.Items = _mapper.Map<IEnumerable<RoleViewModel>>(data);
            return model;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllActiveAsync()
        {
            var roles = await _roleManager.Roles.Where(s => s.IsActive && !s.IsDeleted).ToListAsync();
            return _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        }

        public async Task<bool> UpdateAsync(RoleViewModel model)
        {

            RoleDTO data = await _roleManager.Roles.Where(s => s.Id == model.Id).FirstOrDefaultAsync();
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.Description = model.Description;
            data.IsActive = model.IsActive;
            data.NormalizedName = model.Name.ToUpper();
            data.ModifiedOn = DateTime.Now;
            //data.ModifiedBy = _userInformation.GetUserName();

            var result = await _roleManager.UpdateAsync(data);
            if (result.Succeeded)
            {
                await _unitOfWork.RoleClaimRepository.RemoveSelectedRoleClaimByRoleID(model.Id);
                foreach (var item in model.SelectedRoleClaims)
                {
                    RoleClaimDTO selectedRoleClaim = new RoleClaimDTO() { Id = 0, RoleId = model.Id, RoleClaimId = item.RoleClaimId, RoleClaimGroupId = item.RoleClaimGroupId };
                    var roleClaim = await _unitOfWork.ActionRepository.GetByIdAsync(item.RoleClaimId);
                    var roleClaimGroup = await _unitOfWork.ControllerRepository.GetByIdAsync(item.RoleClaimGroupId);
                    if (roleClaim != null && roleClaimGroup != null)
                    {
                        selectedRoleClaim.ClaimType = roleClaimGroup.Name.Trim() + "_" + roleClaim.Name.Trim();
                        selectedRoleClaim.ClaimValue = roleClaimGroup.Name.Trim() + "_" + roleClaim.Name.Trim();
                        await _unitOfWork.RoleClaimRepository.CreateAsync(selectedRoleClaim);
                    }
                }
                await _unitOfWork.SaveChangesAsync();
            }
            return result.Succeeded;
        }

        public async Task<RoleViewModel> GetEagerRoleByIdAsync(int id)
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            var data = await _roleManager.Roles.Where(s => s.Id == id).Include(x => x.RoleClaims).FirstOrDefaultAsync();
            if (data != null)
            {
                roleViewModel = _mapper.Map<RoleViewModel>(data);
            }
            return roleViewModel;
        }

        public async Task<RoleViewModel> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleViewModel>(data);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var data = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            data.IsDeleted = true;
            //data.ModifiedBy = _userInformation.GetUserName();
            data.ModifiedOn = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
