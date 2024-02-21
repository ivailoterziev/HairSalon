namespace HairSalon.Data
{
    public class Articuls:Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manifacture { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}
