using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class TypeLamination
    {
        [Key]
        public int IdTypeLam { get; set; }
        public string TypeLam { get; set; }
    }
}