using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.Domain.Service
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException("Repository cannot be null");
        }

        public List<User> GetUsers()
        {
            return _userRepository.FindAll();
        }

        public List<UserDTO> GetUserDtos()
        {
            return _userRepository.FindAll().Select(u => new UserDTO(u)).ToList();
        }

        public User GetById(int id)
        {
            return _userRepository.ReadById(id);
        }

        public UserDTO Create(CreateUserDTO user)
        {
            //TODO: move password check to service-level instead of repo. level for easier readability
            var newUser = _userRepository.Create(new User
            {
                Username = user.Username,
                BirthDate = DateTime.Parse(user.BirthDate),
                CapScore = 0
            });

            return new UserDTO(newUser);
        }

        public bool DeleteById(int id)
        {
            return _userRepository.DeleteById(id);
        }

        public User UpdateUser(int id, User user)
        {
            return _userRepository.UpdateUser(id, user);
        }

        public List<UserLimitedInfoDTO> SearchByUsername(string search)
        {
            return _userRepository.SearchByUsername(search).Select(u=> new UserLimitedInfoDTO(u)).ToList();
        }
    }
}