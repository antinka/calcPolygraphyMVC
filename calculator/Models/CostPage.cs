using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CostPage
    {
            [Key]
            public int IdCostPages { get; set; }
            public int IdDensitiesPage { get; set; }
            public Double CostPaper { get; set; }
        
    }
}