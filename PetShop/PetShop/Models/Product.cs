using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public ProductType ProductType { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public AnimalType AnimalType { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
    public enum AnimalType
    {
        [Description("Cat")]
        Cat,

        [Description("Dog")]
        Dog,

        [Description("Small animal")]
        Small_animal,

        [Description("Fish")]
        Fish,

        [Description("Bird")]
        Bird
    }

    public enum ProductType
    {
        [Description("Food")]
        Food,

        [Description("Toy")] 
        Toy,

        [Description("Medication")] 
        Medication,

        [Description("Treat")] 
        Treat,

        [Description("Accessories")] 
        Accessories
    }
}
