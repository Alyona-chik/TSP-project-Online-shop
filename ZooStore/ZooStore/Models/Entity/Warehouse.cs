using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Warehouse
    {
        [Key]
        public long Id { get; set; }

        public int quantity { get; set; }
    }
}
