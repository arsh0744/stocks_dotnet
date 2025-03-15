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
        [Route("api/startStockDataFetch")]
        public void startDataFetch(bool toStart)
        {
            _stocks.startStockDataFetch(toStart);
        }
    }
}
