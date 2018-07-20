using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalysis.Services
{
    public class InMemoryStocksymbolData : IStocksymbolData
    {
        public InMemoryStocksymbolData()
        {
            _stocksymbols = new List<Stocksymbol>
            {
                new Stocksymbol { Id = 1, Name = "APPL"},
                new Stocksymbol { Id = 2, Name = "GOOG"},
                new Stocksymbol { Id = 3, Name = "FACEBOOK"}
            };
        }

        public IEnumerable<Stocksymbol> GetAll()
        {
            return _stocksymbols.OrderBy(r => r.Name);
        }

        public Stocksymbol Get(int id)
        {
            return _stocksymbols.FirstOrDefault(r => r.Id == id);
        }

        public Stocksymbol Add(Stocksymbol stocksymbol)
        {
            stocksymbol.Id = _stocksymbols.Max(r => r.Id) + 1;
            _stocksymbols.Add(stocksymbol);
            return stocksymbol;
        }

        public Stocksymbol Update(Stocksymbol stocksymbol)
        {
            throw new NotImplementedException();
        }

        List<Stocksymbol> _stocksymbols;
    }
}
