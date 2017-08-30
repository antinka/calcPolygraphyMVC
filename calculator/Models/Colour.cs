using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class Colour
    {
        [Key]
        public int IdColour { get; set; }
        public string Name { get; set; }
    }
}