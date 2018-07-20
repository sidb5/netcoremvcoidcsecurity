using Microsoft.AspNetCore.Mvc;
using StockAnalysis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalysis.ViewComponents
{
    public class CurrentMutualFundViewComponent : ViewComponent
    {
        private ICurrentMutualFund _currentMutualFund;

        public CurrentMutualFundViewComponent(ICurrentMutualFund currentMutualFund)
        {
            _currentMutualFund = currentMutualFund;
        }

        public IViewComponentResult Invoke()
        {
            var model = _currentMutualFund.GetTopStockCategoryInMF();
            return View("Default", model);
        }

    }
}
