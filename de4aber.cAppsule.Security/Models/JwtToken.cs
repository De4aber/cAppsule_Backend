namespace de4aber.cAppsule.Security.Models
{
    public class JwtToken
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
        
        public int UserId { get; set; }
    }
}