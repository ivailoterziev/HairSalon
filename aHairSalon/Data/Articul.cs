using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Data
{
    public class Articul
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manifacture { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime RegisterOn { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
