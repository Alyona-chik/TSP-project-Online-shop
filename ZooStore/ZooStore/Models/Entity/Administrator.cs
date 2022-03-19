﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Entity
{
    public class Administrator
    {
        [Key]
        public long Id { get; set; }
    
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }

        public Login login { get; set; }
    }
}
