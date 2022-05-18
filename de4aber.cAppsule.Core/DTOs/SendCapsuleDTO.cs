namespace de4aber.cAppsule.Core.DTOs
{
    public class SendCapsuleDTO
    {
        public int SenderId { get; set; }
        public string RecieverUsername { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Photo { get; set; }
    }
}