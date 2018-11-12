using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample
{
    public class Utils
    {
        public static decimal GetDividendYield(string stock, decimal price)
        {
            decimal dividendYield = 0;
            Tuple<string, decimal, decimal?, decimal> trade;
            if (TradeData.tradeInInformation.TryGetValue(stock, out trade))
            {
                switch (trade.Item1.ToLower())
                {
                    case "common":
                        dividendYield = trade.Item2 / price;
                        break;
                    case "preferred":
                        dividendYield = (trade.Item3.Value * trade.Item4) / (100 * price);
                        break;
                }
            }
            return dividendYield;
        }

        public static decimal GetPERatio(string stock, decimal price)
        {
            decimal peRatio = 0;
            Tuple<string, decimal, decimal?, decimal> trade;
            if (TradeData.tradeInInformation.TryGetValue(stock, out trade))
            {
                try
                {
                    peRatio = price / trade.Item2;
                }
                catch { }
            }
            return peRatio;
        }

        public static decimal VolumeWeightedStockPrice(string stock, decimal quantity, List<Trade> trades)
        {
            decimal volumeWeightedStockPrice = 0;
            List<Trade> filteredTrades = trades.Where(x => x.Symbol == stock && (DateTime.Now - x.TimeStamp).Minutes <= 5).ToList();
            decimal sumPrice = filteredTrades.Sum(x => x.Price);
            decimal sumQuantity = filteredTrades.Sum(x => x.Quantity);
            try
            {
                volumeWeightedStockPrice = (sumPrice * quantity) / sumQuantity;
            }
            catch { }
            return volumeWeightedStockPrice;
        }

        public static double AllShareIndex(string stock, List<Trade> trades)
        {
            double allShareIndex = 0;
            List<string> symbols = (from t in trades select t.Symbol).Distinct().ToList();
            decimal price = 1;
            foreach (var symbol in symbols)
            {
                price = price * VolumeWeightedStockPrice(symbol, 1, trades.Where(x => x.Symbol == symbol).ToList());
            }
            try
            {
                allShareIndex = Math.Pow(double.Parse(price.ToString()), 1 / symbols.Count);
            }
            catch { }
            return allShareIndex;
        }
    }
}
