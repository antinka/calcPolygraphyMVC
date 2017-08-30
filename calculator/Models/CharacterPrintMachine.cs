using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CharacterPrintMachine
    {
        [Key]
        public int Id { get; set; }
        public int QuantityListInMinute { get; set; }
    }
}