using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Product_Type
    {
        [Key]
        public long Id { get; set; }

        public short type { get; set; }

        public List<Product> products { get; set; }
    }
}
