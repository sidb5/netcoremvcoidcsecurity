using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockAnalysis.Models
{
    public class Stocksymbol
    {
        public int Id { get; set; }

        [Display(Name="Stocksymbol Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public StockType Stock { get; set; }
    }
}
