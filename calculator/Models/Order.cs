using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdFormatProduct { get; set; }
        public int IdTypePapers { get; set; }
        public int IdDensity { get; set; }
        public int IdColour { get; set; }
        public int quantity { get; set; }
        public int IdTypeLam { get; set; }
        public int IdDensityLam { get; set; }
        public int IdBigovki { get; set; }
        public int IdFaltsovki { get; set; }
        public int IdRoundAngle { get; set; }
        public double CostOrger { get; set; }
        public int IdStatusOrder { get; set; }
        public DateTime DataOrderMake { get; set; }
    }
}