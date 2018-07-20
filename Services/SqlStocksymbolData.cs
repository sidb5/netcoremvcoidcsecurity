using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockAnalysis.Models;
using StockAnalysis.Data;
using Microsoft.EntityFrameworkCore;

namespace StockAnalysis.Services
{
    public class SqlStocksymbolData : IStocksymbolData
    {
        private StockAnalysisDbContext _context;

        public SqlStocksymbolData(StockAnalysisDbContext context)
        {
            _context = context;
        }

        public Stocksymbol Add(Stocksymbol stocksymbol)
        {
            _context.Stocksymbols.Add(stocksymbol);
            _context.SaveChanges();
            return stocksymbol;
        }

        public Stocksymbol Get(int id)
        {
            return _context.Stocksymbols.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Stocksymbol> GetAll()
        {
            return _context.Stocksymbols.OrderBy(r => r.Name);
        }

        public Stocksymbol Update(Stocksymbol stocksymbol)
        {
            _context.Attach(stocksymbol).State = 
                EntityState.Modified;
            _context.SaveChanges();
            return stocksymbol;
        }
    }
}
