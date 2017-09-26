using System;
using System.Collections.Generic;
using System.Linq;
using Bakery.Database;
using Bakery.Database.Models;
using Bakery.Repositories.Interfaces;

namespace Bakery.Repositories.Implementations
{
    public class Repository:IRepository
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var items = _context.Products.Where(n => n.BakingTime.AddHours(n.LifeHours) > DateTime.Now).ToList();
            return items;
        }
    }
}