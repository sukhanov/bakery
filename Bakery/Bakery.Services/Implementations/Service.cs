using System;
using System.Collections.Generic;
using System.Linq;
using Bakery.Common.Infra.Enums;
using Bakery.Repositories.Interfaces;
using Bakery.Services.Interfaces;
using Bakery.Services.Mapper;
using Bakery.Services.Models;

namespace Bakery.Services.Implementations
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var items = _repository.GetAllProducts().ToList();
            var mapped = items.Select(ProductMapper.Product2ProductModel).ToList();

            foreach (var product in mapped)
            {
                SetCurrentPrice(product);
                SetForecast(product);
            }

            return mapped;
        }

        private static void SetCurrentPrice(ProductModel product)
        {
            var priceCoef = 1;
            product.CurrentPrice = product.StartPrice;

            switch (product.Type)
            {
                case BakeryType.Pretzel:
                    if (product.BakingTime.AddHours(product.FreshHours) <= DateTime.Now)
                        product.CurrentPrice /= 2;
                    return;
                case BakeryType.SourCream:
                    priceCoef = 2;
                    break;
                case BakeryType.Croissant:
                    break;
                case BakeryType.Baguette:
                    break;
                case BakeryType.Loaf:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var totalHours = (DateTime.Now - product.BakingTime).Hours;
            product.CurrentPrice = CalcPrice(product.StartPrice, totalHours, priceCoef);
        }

        private static void SetForecast(ProductModel product)
        {
            var priceCoef = 1;

            switch (product.Type)
            {
                case BakeryType.Pretzel:
                    var freshEnd = product.BakingTime.AddHours(product.FreshHours);
                    if (freshEnd <= DateTime.Now) return;
                    product.NextPrice = product.CurrentPrice / 2;
                    product.NextPriceChangeTime = freshEnd;
                    return;
                case BakeryType.SourCream:
                    priceCoef = 2;
                    break;
                case BakeryType.Croissant:
                    break;
                case BakeryType.Baguette:
                    break;
                case BakeryType.Loaf:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var totalHours = (DateTime.Now - product.BakingTime).Hours + 1;
            product.NextPriceChangeTime = product.BakingTime.AddHours(totalHours);
            product.NextPrice = CalcPrice(product.StartPrice, totalHours, priceCoef);
        }

        private static decimal CalcPrice(decimal start, int hours, int coef)
        {
            var price = start;
            var i = 1;
            while (i <= hours)
            {
                price -= price * 0.02m * coef;
                i++;
            }
            return price;
        }
    }
}