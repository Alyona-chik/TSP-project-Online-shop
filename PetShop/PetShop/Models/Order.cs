using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public OrderStatus OrderStatus { get; set; }
        public string? Address { get; set; }

        [ForeignKey("CartId")]
        public long CartId { get; set; }
        public virtual Cart? Cart { get; set; }
    }

    public enum OrderStatus
    {
        [Description("Accepted")]
        Accepted,

        [Description("Delivered")]
        Delivered
    }
}
