using System;
using Bakery.Common.Infra.Enums;

namespace Bakery.Services.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public BakeryType Type { get; set; }
        public DateTime BakingTime { get; set; }
        public int LifeHours { get; set; }
        public int FreshHours { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal NextPrice { get; set; }
        public DateTime NextPriceChangeTime { get; set; }
    }
}