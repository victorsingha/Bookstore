using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Bookstore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IUserRL, UserRL>();

            container.RegisterType<IBookBL, BookBL>();
            container.RegisterType<IBookRL, BookRL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}