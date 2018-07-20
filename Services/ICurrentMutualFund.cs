using Microsoft.Extensions.Configuration;

namespace StockAnalysis.Services
{
    public interface ICurrentMutualFund
    {
        string GetTopStockCategoryInMF();
    }

    public class CurrentMutualFund : ICurrentMutualFund
    {
        private IConfiguration _configuration;

        public CurrentMutualFund(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetTopStockCategoryInMF()
        {
            return _configuration["TopCategory"];
        }
    }
}