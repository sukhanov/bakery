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
                NextPriceChangeTime = source.NextPriceChangeTime.ToString("dd.MM.yyyy HH.mm"),
                StartPrice = source.StartPrice,
                CurrentPrice = source.CurrentPrice,
                NextPrice = source.NextPrice,
                Type = source.Type.GetDescription()
            };
            return target;
        }
    }
}