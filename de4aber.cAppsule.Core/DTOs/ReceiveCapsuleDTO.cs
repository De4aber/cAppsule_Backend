namespace de4aber.cAppsule.Core.DTOs
{
    public class ReceiveCapsuleDTO
    {
        public ReceiveCapsuleDTO(int capsuleId, string senderUsername)
        {
            CapsuleId = capsuleId;
            SenderUsername = senderUsername;
        }

        public int CapsuleId { get; set; }
        public string  SenderUsername { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Photo { get; set; }
    }
}