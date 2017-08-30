using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class RoundAngle
    {
        [Key]
        public int IdRoundAngle { get; set; }
        public string TypeRoundAngle { get; set; }
        public double CostRoundAngle { get; set; }
    }
}