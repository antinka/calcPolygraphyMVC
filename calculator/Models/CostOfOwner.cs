using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CostOfOwner
    {
        [Key]
        public int Id { get; set; }
        public int ReturnInvestision { get; set; }
        public int Salary { get; set; }
        public int Rent { get; set; }
        public int CostOwnMachine { get; set; }
        public int GeneralProdSpend{ get; set; }
        public double TimeWorkingInMonth { get; set; }
    }
}