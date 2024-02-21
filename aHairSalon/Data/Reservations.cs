namespace HairSalon.Data
{
    public class Reservations
    {
     public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public DateTime DataReservation { get; set; }
        public DateTime TimeReservation { get; set; }
        public DateTime OrderOn { get; set; }
    }
}
