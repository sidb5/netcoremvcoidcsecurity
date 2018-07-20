using Microsoft.EntityFrameworkCore;
using StockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalysis.Data
{
    public class StockAnalysisDbContext : DbContext
    {
        public StockAnalysisDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Stocksymbol> Stocksymbols { get; set; }
    }
}
