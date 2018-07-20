using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalysis.Services
{
    public interface IStocksymbolData
    {
        IEnumerable<Stocksymbol> GetAll();
        Stocksymbol Get(int id);
        Stocksymbol Add(Stocksymbol stocksymbol);
        Stocksymbol Update(Stocksymbol stocksymbol);
    }
}
