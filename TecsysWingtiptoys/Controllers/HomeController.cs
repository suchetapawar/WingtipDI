using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DAL;
using System.Collections.Generic;

namespace TecsysWingtiptoys.Controllers
{
    /// <summary>
    /// Date: 5/4/2020
    /// Created By: Sucheta Pawar
    /// Home Page - Main Page
    /// </summary>
    public class HomeController : Controller
    {
        //Declare the dependency
        private IProductRepository _iProductRepository;

        //Inject the dependency for Data Access Layer
        public HomeController(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        /// <summary>
        /// Index action will be called by default on homecontroller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Call the method which will return the model for the view
            //return View(_iProductRepository.GetProducts(ConfigurationManager.AppSettings.GetValues("ProductType").First()));
            return View(_iProductRepository.GetProducts());
        }
    }
}