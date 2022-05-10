using de4aber.cAppsule.Core.Models;

namespace de4aber.cAppsule.DataAccess.Entities
{
    public class CappsuleEntity
    {
        public int id { get; set; }
        public int sender { get; set; }
        public int reciever { get; set; }
        public double lattitude { get; set; }
        public double longitute { get; set; }
        public string openTime { get; set; }
        public Photo image { get; set; }

        public CappsuleEntity(Cappsule cappsule)
        {
            id = cappsule.id;
            sender = cappsule.sender;
            reciever = cappsule.reciever;
            lattitude = cappsule.lattitude;
            longitute = cappsule.longitute;
            openTime = cappsule.openTime;
            image = cappsule.image;
        }

        public Cappsule toCappsule()
        {
            return new Cappsule()
            {
                id = id,
                sender = sender,
                reciever = reciever,
                lattitude = lattitude,
                longitute = longitute,
                openTime = openTime,
                image = image
            };
        }
        
        public CappsuleEntity(){}
    }
}