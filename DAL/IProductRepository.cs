using DAL.ProductModels;
using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    /// Date: 5/4/2020
    /// Created By: Sucheta Pawar
    /// This is interface which mentions which methods needs to be implemented in productrepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Date: 5/4/2020
        /// Created By: Sucheta Pawar
        /// Reads all the products of given product category
        /// </summary>
        /// <param name="prodType">This is the Category of the vehicle - e.g. "Cars", "Trucks" etc </param>
        /// <returns>Lists of products belonging to given type</returns>
        //List<Product> GetProducts(string prodType);
        List<Product> GetProducts();
    }
}
