namespace Bakery.Web.Models
{
    public class WebProductModel
    {
        public string Name { get; set; }
        public string BakingTime { get; set; }
        public string Type { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal NextPrice { get; set; }
        public string NextPriceChangeTime { get; set; }
    }
}