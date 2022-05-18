using System;
using System.Reflection.Metadata;
using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.DataAccess.Entities
{
    public class CapsuleEntity
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Photo { get; set; }

        public Capsule ToCapsule()
        {
            return new Capsule()
            {
                Id = Id,
                SenderId = SenderId,
                ReceiverId = ReceiverId,
                Message = Message,
                Time = IfTimeNull(Time),
                Latitude = Latitude,
                Longitude = Longitude,
                Photo = Photo
            };
        }

        private static DateTime? IfTimeNull(string? str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return Convert.ToDateTime(str);
        }

        public CapsuleEntity(Capsule capsule)
        {
            Id = capsule.Id;
            ReceiverId = capsule.ReceiverId;
            SenderId = capsule.SenderId;
            Message = capsule.Message;
            Time = capsule.Time.ToString();
            Latitude = capsule.Latitude;
            Longitude = capsule.Longitude;
            Photo = capsule.Photo;

        }

        public CapsuleEntity()
        {
        }
    }
}