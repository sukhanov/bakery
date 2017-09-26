using System;
using Bakery.Common.Infra.Enums;

namespace Bakery.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public BakeryType Type { get; set; }
        public DateTime BakingTime { get; set; }
    }
}