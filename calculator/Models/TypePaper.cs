using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class TypePaper
    {
             [Key]
        public int IdTypePapers { get; set; }
        public string Name { get; set; }
        public int IdFormatPaper { get; set; }
    }
}