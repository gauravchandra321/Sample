using System;
using System.Collections.Generic;

namespace Sample
{
    class Program
    {
        static List<Trade> trades = new List<Trade>();

        static void Main(string[] args)
        {
            bool enterTrade = true;
            while (enterTrade)
            {
                GetTradeDetails();
                Console.WriteLine("Do you want to continue(Y/N)?:");
                string value = Console.ReadLine();
                if (value.ToLower() == "y") { value = "True"; }
                else if (value.ToLower() == "n") { value = "False"; }

                bool.TryParse(value, out enterTrade);
            }
            if (!enterTrade)
            {
                Console.WriteLine("Below are all the trades entered:");
                foreach (var trade in trades)
                {
                    Console.WriteLine(string.Format("Symbol: {0} , TimeStamp: {1} , Quantity: {2} , Buy/Sell: {3}",trade.Symbol,trade.TimeStamp,trade.Quantity,trade.BuySell));
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }

        private static void GetTradeDetails()
        {
            Trade trade = new Trade();
            try
            {
                Console.WriteLine("Please enter the trade details.");
                Console.Write("Stock Symbol:");
                trade.Symbol = Console.ReadLine();
                Console.Write("Quantity:");
                trade.Quantity = decimal.Parse(Console.ReadLine());
                Console.Write("Buy/Sell:");
                string type = Console.ReadLine();
                trade.BuySell = (TradeType)Enum.Parse(typeof(TradeType),type);
                Console.Write("Price:");
                trade.Price = decimal.Parse(Console.ReadLine());
                trade.TimeStamp = DateTime.Now;

                trades.Add(trade);

                Console.WriteLine(string.Format("Dividend Yield: {0}",Utils.GetDividendYield(trade.Symbol,trade.Price)));
                Console.WriteLine(string.Format("PE Ratio: {0}", Utils.GetPERatio(trade.Symbol,trade.Price)));
                Console.WriteLine(string.Format("Volume Weighted Stock Price: {0}",Utils.VolumeWeightedStockPrice(trade.Symbol,trade.Quantity,trades)));
                Console.WriteLine(string.Format("All Share Index: {0}",Utils.AllShareIndex(trade.Symbol,trades)));
            }
            catch
            {
                trades.Remove(trade);
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
