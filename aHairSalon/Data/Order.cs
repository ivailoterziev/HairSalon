namespace HairSalon.Data
{
    public class Order
    {
        public int Id { get; set; } 
        public string ArticulId { get; set; }
        public string ClientId { get; set; }
        public string Quantity { get; set; }
        public Order Orders { get; set; }
       

    }
}
