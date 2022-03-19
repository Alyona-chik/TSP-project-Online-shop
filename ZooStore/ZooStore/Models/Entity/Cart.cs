using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Cart
    {
        [Key]
        public long Id { get; set; }

        public int product_quantity { get; set; }
        public double total_money { get; set; }

        public List<Customer> customers { get; set; }
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }
    }
}
