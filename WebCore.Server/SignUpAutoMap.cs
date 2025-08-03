using AutoMapper;
using Common.ViewModels.SystemViewModels;
using DataAccess.DTOs;

namespace LulusiaAdmin.Server
{
    public class SignUpAutoMap : Profile
    {
        public SignUpAutoMap()
        {
            #region System
            CreateMap<RoleDTO, RoleViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<ModuleDTO, ModuleViewModel>().ReverseMap();
            CreateMap<ControllerDTO, ControllerViewModel>().ReverseMap();
            CreateMap<ControllerActionDTO, ControllerActionViewModel>().ReverseMap();
            CreateMap<ActionDTO, ActionViewModel>().ReverseMap();
            #endregion
        }
    }
}
