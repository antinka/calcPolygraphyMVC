using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class StatusOrder
    {
        [Key]
        public int IdStatusOrder { get; set; }
   public string Status{ get; set; }
    }
}