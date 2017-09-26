using System.Collections.Generic;
using Bakery.Database.Models;

namespace Bakery.Repositories.Interfaces
{
    /// <summary>
    /// Основной репозиторий 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получить список всех продуктов пекарни
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProducts();
    }
}