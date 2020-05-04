using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecsysWingtiptoys.Controllers;
using DAL;
using Moq;
using DAL.ProductModels;

namespace TecsysWingtiptoys.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IProductRepository> mockProductRepository;
        private List<Product> mockProducts;

        [TestInitialize]
        public void SetupTests()
        {
            //Inject mock objects to test the controller
            mockProductRepository = new Mock<IProductRepository>();

            mockProducts = new List<Product>() { new Product { ProductID = 1, ProductName = "Product1", UnitPrice = 100, CategoryID = 1, ImagePath = "1.jpg" }
                    ,new Product {ProductID = 2, ProductName = "Product2", UnitPrice = 200, CategoryID = 1, ImagePath = "2.jpg" }
                    ,new Product {ProductID = 3, ProductName = "Product3", UnitPrice = 300, CategoryID = 1, ImagePath = "3.jpg" }
                    ,new Product {ProductID = 4, ProductName = "Product4", UnitPrice = 400, CategoryID = 1, ImagePath = "4.jpg" }
                    };
            mockProductRepository.Setup(m => m.GetProducts()).Returns(mockProducts);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(mockProductRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            List<Product> output = (List<Product>)result.Model;

            // Assert
            for (int i = 0; i < output.Count; i++)
            {
                Assert.AreEqual(mockProducts[i].ProductID, output[i].ProductID);
                Assert.AreEqual(mockProducts[i].ProductName, output[i].ProductName);
                Assert.AreEqual(mockProducts[i].UnitPrice, output[i].UnitPrice);
                Assert.AreEqual(mockProducts[i].CategoryID, output[i].CategoryID);
                Assert.AreEqual(mockProducts[i].ImagePath, output[i].ImagePath);
            }
        }
    }
}
