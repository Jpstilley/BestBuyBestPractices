using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public void CreateProduct(string newName, double newPrice, int newCategoryID, int newOnSale, int newStockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);",
                new { name = newName,
                      price = newPrice,
                      categoryID = newCategoryID,
                      onSale = newOnSale,
                      stockLevel = newStockLevel } );
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS");
        }

        //public void UpdateProduct(string[] updates )
        //{
        //    var searchedID = _connection.Query<int>("SELECT productID FROM PRODUCTS WHERE Name = @name;",
        //        new { name = updates[2] });

        //    var updateString = $"UPDATE PRODUCTS SET {updates[0]} = {updates[1]} WHERE ProductID = {searchedID}";

        //    _connection.Execute(updateString);
        //        //new { column = updates[0].Trim('"'),
        //        //    newValue = updates[1],
        //        //    prodID = searchedID } );
        //}

        //public string[] ChooseUpdates()
        //{
        //    string[] update = new string[2];
            
        //    Console.WriteLine("Please choose the the product category you would like to update");
        //    Console.WriteLine($"1. Product Name\n 2.Product Price\n3. Product Stock Level");
        //    var userInput = new Regex(Console.ReadLine());
        //    switch(new Regex() { Console.ReadLine() } )
        //        case 
        //}
    }
}
