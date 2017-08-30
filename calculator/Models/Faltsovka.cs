using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Faltsovka
    {
        [Key]
        public int IdFaltsovki { get; set; }
        public string TypeFaltsovki { get; set; }
        public double CostFaltsovki { get; set; }
    }
}