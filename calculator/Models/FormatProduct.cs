using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class FormatProduct
    {
        [Key]
        public int IdFormatProduct { get; set; }
        public string Format { get; set; }
    }
}