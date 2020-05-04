using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DAL;

namespace TecsysWingtiptoys
{
    /// <summary>
    /// Date: 5/4/2020
    /// Created By: Sucheta Pawar
    /// Using Unity container for DI
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            //Registering the dependency here so that Unity Container will inject given dependency on Homecontroller
            container.RegisterType<IProductRepository, ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}