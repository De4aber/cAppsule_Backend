namespace de4aber.cAppsule.Security.Entities
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        
        public int EmployeeId { get; set; }
    }
}