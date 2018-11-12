using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class Trade
    {
        public string Symbol { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Quantity { get; set; }

        public TradeType BuySell { get; set; }

        public decimal Price { get; set; }
    }

    public enum TradeType
    {
        Buy, Sell
    }
}
