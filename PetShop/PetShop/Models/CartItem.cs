using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class CartItem
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        public long CartId { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
