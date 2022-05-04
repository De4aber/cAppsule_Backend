namespace cAppsule
{
    public class Friendship
    {
        public int Id { get; set; }
        public int UserIdRequesting { get; set; }
        public int UserIdRequested { get; set; }
        public bool Accepted { get; set; } = false;
        
    }
}