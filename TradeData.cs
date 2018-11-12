using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public static class TradeData
    {
        public static Dictionary<string, Tuple<string, decimal, decimal?, decimal>> tradeInInformation = new Dictionary<string, Tuple<string, decimal, decimal?, decimal>>
        {
            {"TEA",new Tuple<string, decimal, decimal?, decimal>("Common",0,null,100) },
            {"POP",new Tuple<string, decimal, decimal?, decimal>("Common",8,null,100) },
            {"ALE",new Tuple<string, decimal, decimal?, decimal>("Common",23,null,60) },
            {"GIN",new Tuple<string, decimal, decimal?, decimal>("Preferred",8,2,100) },
            {"JOE",new Tuple<string, decimal, decimal?, decimal>("Common",13,null,250) }
        };
    }
}
