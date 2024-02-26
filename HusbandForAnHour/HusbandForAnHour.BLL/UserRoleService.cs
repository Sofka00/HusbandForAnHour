using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL
{
    public class UserRoleService
    {
        private UserRoleRepository _userRoleRepository;
        private Mapper _mapper;
        public UserRoleService()
        {
            _userRoleRepository = new UserRoleRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserRoleMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public UserRoleOutputModel GetUserRole(int id)
        {
            var userRoleDto = _userRoleRepository.GetUserRole(id);
            var userRoleOutputModel = _mapper.Map<UserRoleOutputModel>(userRoleDto);
            return userRoleOutputModel;
        }

        public void CreateUserRole(string name)
        {
            _userRoleRepository.CreateUserRole(name);
        }

        public int UpdateUserRole(int id, string name)
        {
            return _userRoleRepository.UpdateUserRole(id, name);
        }

        public int DeleteUserRole(int id)
        {
            return _userRoleRepository.DeleteUserRole(id);
        }

        public int RestoreUserRole(int id)
        {
            return _userRoleRepository.RestoreUserRole(id);
        }
    }
}
