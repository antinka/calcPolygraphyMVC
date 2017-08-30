using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Bigovka
    {
        [Key]
        public int IdBigovki {get;set;}
        public string TypeBigovki{get;set;}
        public double CostBigovki{ get; set; }
    }
}