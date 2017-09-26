using System.Collections.Generic;
using Bakery.Services.Models;

namespace Bakery.Services.Interfaces
{
    /// <summary>
    /// Основной сервис
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Получить список всех продуктов пекарни
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetAllProducts();
    }
}