using cAppsule;

namespace de4aber.cAppsule.Core.DTOs
{
    /*
     * User as seen by other users; no id and password
     */
    public class UserLimitedInfoDTO
    {
        public string Username { get; set; }
        public string BirthDate { get; set; }
        public int CapScore { get; set; }

        public UserLimitedInfoDTO(User user)
        {
            Username = user.Username;
            BirthDate = user.BirthDate.ToShortDateString();
            CapScore = user.CapScore;

        }
    }
}