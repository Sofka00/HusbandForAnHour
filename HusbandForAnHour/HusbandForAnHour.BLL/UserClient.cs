using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.InputModels;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL
{
    public class UserClient
    {
        private UserRepository _userRepository;
        private Mapper _mapper;

        public UserClient()
        {
            _userRepository = new UserRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public List<UserOutputModel> GetUsers()
        {
            List<UserDto> userDtos = _userRepository.GetUserById();
            return _mapper.Map<List<UserOutputModel>>(userDtos);


        }
        public void CreateWorker(CreateWorkerInputModel inputModel)
        {
            var convertUserDto = _mapper.Map<UserDto>(inputModel);
            _userRepository.CreateUser(convertUserDto);
        }

        public int GetLastUserId()
        {
            return _userRepository.GetLastUserId();
        }
    }
}
