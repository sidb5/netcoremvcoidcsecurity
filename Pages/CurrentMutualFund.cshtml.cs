using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockAnalysis.Services;

namespace StockAnalysis.Pages
{
    public class CurrentMutualFundModel : PageModel
    {
        private ICurrentMutualFund _currentMutualFund;

        public string CurrentTopStockCategory { get; set; }

        public CurrentMutualFundModel(ICurrentMutualFund currentMutualFund)
        {
            _currentMutualFund = currentMutualFund;
        }

        public void OnGet(string name)
        {
            CurrentTopStockCategory = $"{name}: {_currentMutualFund.GetTopStockCategoryInMF()}";
        }
    }
}