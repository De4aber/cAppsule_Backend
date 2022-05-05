using cAppsule;

namespace de4aber.cAppsule.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string BirthDate { get; set; }
        public int CapScore { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            BirthDate = user.BirthDate.ToShortDateString();
            CapScore = user.CapScore;

        }
    }
}