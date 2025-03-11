using Microsoft.AspNetCore.Mvc;
using StockAnalyticDataFetch.Service;

namespace StockAnalyticDataFetch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : Controller
    {

        private readonly StockService _stocks;

        public StockController(StockService stocks)
        {
            _stocks = stocks;
        }
        [HttpGet]
        public void startDataFetch()
        {
            _stocks.startStockDataFetch();
        }
    }
}
