using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Density
    {
        [Key]
        public int IdDensity { get; set; }
        public int Value { get; set; }
        public int IdTypePapers { get; set; }
    }
}