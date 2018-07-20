using StockAnalysis.Models;
using System.Collections.Generic;

namespace StockAnalysis.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Stocksymbol> Stocksymbols { get; set; }
        public string CurrentTopCategory { get; set; }
    }
}
