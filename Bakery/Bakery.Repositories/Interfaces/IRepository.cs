using System.Collections.Generic;
using Bakery.Database.Models;

namespace Bakery.Repositories.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}