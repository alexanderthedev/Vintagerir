using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Product s= new Product();
            List<Product> ss = new DataSet1TableAdapters.ProductsTableAdapter().GetData().Select(
                x => new Product
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription
                }).ToList();
        }
    }
}
