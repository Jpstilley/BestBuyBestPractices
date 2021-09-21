using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string newName, double newPrice, int newCategoryID, int newOnSale, int newStockLevel);
    }


}
