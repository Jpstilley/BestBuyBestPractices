using System;
using System.IO;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repoDept = new DapperDepartmentRepository(conn);

            var repoProd = new DapperProductRepository(conn);

            var deptList = repoDept.GetAllDepartments();

            var prodList = repoProd.GetAllProducts();



            //repoDept.InsertDepartment("Guitars");

            foreach (var dept in deptList)
            {
                Console.WriteLine($"{dept.DepartmentID}. {dept.Name}");
                Console.WriteLine("--------");
            }

            //repoProd.CreateProduct("Les Paul", 1499.99, 5, 0, 100);

            //foreach (var prod in prodList)
            //{
            //    Console.WriteLine($"{prod.Name}: {prod.Price}");
            //    Console.WriteLine("--------?");
            //}

            string[] telecaster = { "Name", "Telecaster", "Les Paul" };

            repoProd.UpdateProduct(telecaster);

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.Name}: {prod.Price}");
                Console.WriteLine("--------");
            }


        }
    }
}
