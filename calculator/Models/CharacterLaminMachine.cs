using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CharacterLaminMachine
    {
        [Key]
        public int Id { get; set; }
        public int IdFormatList { get; set; }
        public int QuantityListInMinute { get; set; }
      
    }
}