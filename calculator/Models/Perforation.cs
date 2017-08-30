using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Perforation
    {
        [Key]
        public int IdPerforation { get; set; }
        public string TypePerforation { get; set; }
        public double CostPerforation { get; set; }
    }
}