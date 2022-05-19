namespace de4aber.cAppsule.Security.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        
        public int EmployeeId { get; set; }
        
    }
}