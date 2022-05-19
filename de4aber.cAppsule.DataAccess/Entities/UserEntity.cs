using System;
using cAppsule;

namespace de4aber.cAppsule.DataAccess.Entities
{
    public class UserEntity
    {
        public UserEntity(User user)
        {
            Id = user.Id;
            Username = user.Username;
            CapScore = user.CapScore;
            BirthDate = user.BirthDate.ToString();
        }

        public UserEntity()
        {
            
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string BirthDate { get; set; }

        public int CapScore { get; set; }

        public User ToUser()
        {
            return new User()
            {
                Id = Id,
                Username = Username,
                CapScore = CapScore,
                BirthDate = DateTime.Parse(BirthDate)
            };
        }
    }
}