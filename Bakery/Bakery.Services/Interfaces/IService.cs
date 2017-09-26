using System.Collections.Generic;
using Bakery.Services.Models;

namespace Bakery.Services.Interfaces
{
    public interface IService
    {
        IEnumerable<ProductModel> GetAllProducts();
    }
}