using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class UserCart
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [ForeignKey("CartId")]
        public long CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
