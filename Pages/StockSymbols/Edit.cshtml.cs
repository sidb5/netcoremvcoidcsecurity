using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockAnalysis.Services;
using StockAnalysis.Models;
using Microsoft.AspNetCore.Authorization;

namespace StockAnalysis.Pages.Stocksymbols
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private IStocksymbolData _stocksymbolData;

        [BindProperty]
        public Stocksymbol Stocksymbol { get; set; }

        public EditModel(IStocksymbolData stocksymbolData)
        {
            _stocksymbolData = stocksymbolData;
        }

        public IActionResult OnGet(int id)
        {            
            Stocksymbol = _stocksymbolData.Get(id);
            if(Stocksymbol == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _stocksymbolData.Update(Stocksymbol);
                return RedirectToAction("Details", "Home", new { id = Stocksymbol.Id });
            }
            return Page();
        }

    }
}