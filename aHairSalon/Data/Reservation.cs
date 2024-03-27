using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Data
{
    public class Reservation
    {
     public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Services { get; set; }
        public string ClientId { get; set; }
        public Client Clients { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime DataReservation { get; set; }
        public DateTime TimeReservation { get; set; }
        public DateTime OrderOn { get; set; }
    }
}
