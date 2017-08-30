using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class LinqUserOrder
    {
        [Key]
       public int  IdUserOrder{ get; set; }
                public int   IdUser{ get; set; }
                public int IdOrder { get; set; }
    }
}