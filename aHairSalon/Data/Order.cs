namespace HairSalon.Data
{
    public class Order
    {
        public int Id { get; set; } 
        public int ArticulId { get; set; }
        public Articul Articuls { get; set; }

        public string ClientId { get; set; }
        public Client Clients { get; set; }
        public string Quantity { get; set; }
       
    }
}
