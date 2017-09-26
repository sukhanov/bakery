using Bakery.Common;
using Bakery.Services.Models;
using Bakery.Web.Models;

namespace Bakery.Web.Mappers
{
    public static class ProductMapper
    {
        public static WebProductModel ProductModel2WebProductModel(ProductModel source)
        {
            var target = new WebProductModel
            {
                Name = source.Name,
                BakingTime = source.BakingTime.ToString("dd.MM.yyyy HH.mm"),
                NextPriceChangeTime = source.NextPriceChangeTime.HasValue ? source.NextPriceChangeTime.Value.ToString("dd.MM.yyyy HH.mm") : "-",
                StartPrice = source.StartPrice.ToString("N2"),
                CurrentPrice = source.CurrentPrice.ToString("N2"),
                NextPrice = source.NextPrice.HasValue ? source.NextPrice.Value.ToString("N2") : "-",
                Type = source.Type.GetDescription()
            };
            return target;
        }
    }
}