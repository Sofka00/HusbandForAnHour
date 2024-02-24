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
    public class UserRoleClient
    {
        private UserRoleRepository _userRoleRepository;
        private Mapper _mapper;
        public UserRoleClient()
        {
            _userRoleRepository = new UserRoleRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserRoleMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public List<UserRoleOutputModel> GetStatuses()
        {
            List<UserRoleDto> userRoleDtos = _userRoleRepository.GetUserRoleById();
            return _mapper.Map<List<UserRoleOutputModel>>(userRoleDtos);


        }
    }
}
