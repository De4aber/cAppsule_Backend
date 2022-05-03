using System.Collections.Generic;
using System.IO;
using cAppsule;
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

        public User Create(User user)
        {
            //TODO: move password check to service-level instead of repo. level for easier readability
            return _userRepository.Create(user);
        }

        public Login Login(User user)
        {
            return _userRepository.Login(user);
        }
    }
}