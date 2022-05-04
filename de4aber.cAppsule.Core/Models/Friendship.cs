namespace cAppsule
{
    public class Friendship
    {
        public string Id { get; set; }
        public string UserIdRequesting { get; set; }
        public string UserIdRequested { get; set; }
        public bool Accepted { get; set; } = false;
        
    }
}