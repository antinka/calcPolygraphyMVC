using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class DensityLamin
    {
        [Key]
        public int IdLam { get; set; }
        public int DensityLam { get; set; }
        public int TypeLamId { get; set; }
    }
}