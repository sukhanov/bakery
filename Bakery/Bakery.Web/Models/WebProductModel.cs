namespace Bakery.Web.Models
{
    public class WebProductModel
    {
        public string Name { get; set; }
        public string BakingTime { get; set; }
        public string Type { get; set; }
        public string StartPrice { get; set; }
        public string CurrentPrice { get; set; }
        public string NextPrice { get; set; }
        public string NextPriceChangeTime { get; set; }
    }
}