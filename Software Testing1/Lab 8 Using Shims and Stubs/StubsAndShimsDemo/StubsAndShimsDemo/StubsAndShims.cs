using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubsAndShimsDemo
{
    public interface IStockFeed
    {
        int GetSharePrice(string company);
        T GetValue<T>(); // Method of a generic type
        int MySampleValue { get; set; }
    }

    public class StockAnalyzer
    {
        private IStockFeed stockFeed;
        public StockAnalyzer(IStockFeed feed)
        {
            stockFeed = feed;
        }
        public int GetContosoPrice()
        {
            return stockFeed.GetSharePrice("COOO");
        }
    }
    /////////////////////////////////////////
    // Code under test (for STUB usage) - END
    /////////////////////////////////////////

    /////////////////////////////////////////
    // Code under test (for SHIM usage) - START
    /////////////////////////////////////////
    public class Y2KChecker
    {
        public int Check()
        {
            if (DateTime.Now == new DateTime(2000, 1, 1))
                throw new ApplicationException("y2kbug!");
            DateTime now = DateTime.Now;
            return now.Year;
        }
    }
    /////////////////////////////////////////
    // Code under test (for SHIM usage) - END
    /////////////////////////////////////////
}
