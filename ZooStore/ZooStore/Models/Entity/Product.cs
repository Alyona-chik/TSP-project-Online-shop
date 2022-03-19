using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        public string name{ get; set; }

        public Type type { get; set; }

        public Cart cart { get; set; }

        public Animal_Type animalType { get; set; }
    }
}
