﻿using AutoMapper;
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
    public class UserService
    {
        private UserRepository _userRepository;
        private Mapper _mapper;

        public UserService()
        {
            _userRepository = new UserRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public UserOutputModel GetUser(long id)
        {
            var userDto = _userRepository.GetUser(id);

            var userOutputModel = _mapper.Map<UserOutputModel>(userDto);
            return userOutputModel;
        }

        public void CreateUser(int roleId, string firstName, string secondName, long phone)
        {
            _userRepository.CreateUser(roleId, firstName, secondName, phone);
        }

        public int UpdateUser(long id, int roleId, string firstName, string secondName, long phone)
        {
            return _userRepository.UpdateUser(id, roleId, firstName, secondName, phone);
        }

        public int DeleteUser(long id)
        {
            return _userRepository.DeleteUser(id);
        }

        public int RestoreUser(long id)
        {
            return _userRepository.RestoreUser(id);
        }
    }
}
