using System.Collections.Generic;
using System.Linq;
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

            return mapped;
        }
    }
}