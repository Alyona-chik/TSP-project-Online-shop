using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public DateTime ortder_date { get; set; }
        public DateTime delivery_date { get; set; }
        public short status { get; set; }

        public Cart cart { get; set; }
    }
}
