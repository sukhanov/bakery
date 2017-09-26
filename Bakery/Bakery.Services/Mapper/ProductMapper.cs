using Bakery.Database.Models;
using Bakery.Services.Models;

namespace Bakery.Services.Mapper
{
    public static class ProductMapper
    {
        public static ProductModel Product2ProductModel(Product source)
        {
            var target = new ProductModel
            {
                Name = source.Name,
                BakingTime = source.BakingTime,
                FreshHours = source.FreshHours,
                StartPrice = source.Price,
                LifeHours = source.LifeHours,
                Type = source.Type
            };
            return target;
        }
    }
}