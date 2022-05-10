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
    }
}