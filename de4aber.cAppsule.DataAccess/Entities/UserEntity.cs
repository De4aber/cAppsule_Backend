using System;
using cAppsule;

namespace de4aber.cAppsule.DataAccess.Entities
{
    public class UserEntity
    {
        public UserEntity(User user)
        {
            Id = int.Parse(user.Id);
            Username = user.Username;
            CapScore = Int32.Parse(user.CapScore);
        }

        public UserEntity()
        {
            
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public int CapScore { get; set; }

        public User ToUser()
        {
            return new User()
            {
                Id = Id.ToString(),
                Username = Username,
                CapScore = CapScore.ToString()
            };
        }
    }
}