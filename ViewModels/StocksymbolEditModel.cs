using StockAnalysis.Models;
using System.ComponentModel.DataAnnotations;

namespace StockAnalysis.ViewModels
{
    public class StocksymbolEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public StockType Stock { get; set; }
    }
}
