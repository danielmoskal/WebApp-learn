using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace drugaApka
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "AddCar",
            //    url: "Dodaj",
            //    defaults: new { Controller = "ManageCars", action = "Add" }
            //);

            //routes.MapRoute(
            //    name: "VievCars",
            //    url: "Wyswietl",
            //    defaults: new { Controller = "ManageCars", action = "View" }
            //);

            //routes.MapRoute(
            //    name: "RemoveCar",
            //    url: "Usun",
            //    defaults: new { Controller = "ManageCars", action = "RemoveAll" }
            //);

            //routes.MapRoute(
            //    name: "SearchCars",
            //    url: "Szukaj",
            //    defaults: new { Controller = "ManageCars", action = "Search" }
            //);

            routes.MapRoute(
                name: "Wydatki",
                url: "Expense",
                defaults: new { Controller = "RentFlat", action = "Expenses" }
            );

            routes.MapRoute(
                name: "Wpłaty",
                url: "Pay",
                defaults: new { Controller = "RentFlat", action = "PayMoney" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
