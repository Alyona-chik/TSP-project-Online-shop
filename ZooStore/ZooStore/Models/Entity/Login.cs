using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Login
    {
        [Key]
        public long Id { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public List<Customer> customers { get; set; }
        public List<Administrator> administrators { get; set; }
    }
}
