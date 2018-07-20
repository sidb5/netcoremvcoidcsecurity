using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockAnalysis.Models;
using StockAnalysis.Services;
using StockAnalysis.ViewModels;

namespace StockAnalysis.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IStocksymbolData _stocksymbolData;
        private ICurrentMutualFund _currentMutualFund;

        public HomeController(IStocksymbolData stocksymbolData,
                              ICurrentMutualFund currentMutualFund)
        {
            _stocksymbolData = stocksymbolData;
            _currentMutualFund = currentMutualFund;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Stocksymbols = _stocksymbolData.GetAll();
            model.CurrentTopCategory = _currentMutualFund.GetTopStockCategoryInMF();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _stocksymbolData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]   
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StocksymbolEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newStocksymbol = new Stocksymbol();
                newStocksymbol.Name = model.Name;
                newStocksymbol.Stock = model.Stock;

                newStocksymbol = _stocksymbolData.Add(newStocksymbol);

                return RedirectToAction(nameof(Details), new { id = newStocksymbol.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
