using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public long Id { get; set; }
        public int ProductQuantity { get; set; }
        public double TotalMoney { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        public virtual ICollection<UserCart>? UserCarts { get; set; } = new List<UserCart>();

        public void setProductQuantity()
        {
            this.ProductQuantity++;
        }
        public void setTotalMoney(double price)
        {
            this.TotalMoney += price;
        }


    }

}
