using de4aber.cAppsule.DataAccess.Entities;

namespace de4aber.cAppsule.Core.Models
{
    public class Cappsule
    {
        public int id { get; set; }
        public int sender { get; set; }
        public int reciever { get; set; }
        public double lattitude { get; set; }
        public double longitute { get; set; }
        public string openTime { get; set; }
        public Photo image { get; set; }
    }
}