using DAL.ProductModels;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// Date: 5/4/2020
    /// Created By: Sucheta Pawar
    /// This is a product repository which currently returns the products
    /// This can be extended in order to expose different methods related to product category
    /// This is implementing IProductRepository which specifies all the methods which needs to be implemented
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Date: 5/4/2020
        /// Created By: Sucheta Pawar
        /// Implements the method from IProductRepository
        /// </summary>
        /// <param name="prodType">Vehicle Category</param>
        /// <returns>Lists of products belonging to given type</returns>
        //List<Product> IProductRepository.GetProducts(string prodType)
        List<Product> IProductRepository.GetProducts()
        {
            try
            {
                using (var dbContext = new wingtipEntities())
                {
                    string prodType = ConfigurationManager.AppSettings.GetValues("ProductType").First();
                    IEnumerable<Product> allProducts = from products in dbContext.Products
                                                       join cats in dbContext.Categories 
                                                       on products.CategoryID equals cats.CategoryID
                                                       where (cats.CategoryName == prodType)
                                                       select products;

                    return allProducts.ToList();
                }
            }
            catch
            {
                /*TODO - Handle exception and save the log in database or a file depending on the design
                 This log should have all the details like user name, date, time 
                 so that this will help afterwards to identify the problem*/

                //Trying to avoid propogation of exception to business layer
                //return new List<Product>();
                throw;
            }

        }
    }
}
