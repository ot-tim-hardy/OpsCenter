using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using OpsCenter.Models;

namespace OpsCenter {
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}

		protected void Application_Start() {
			//Database.SetInitializer<OpsCenterDB>(null);
			
			var builder = new ContainerBuilder();
			Assembly myAssembly = Assembly.GetExecutingAssembly();
			builder.RegisterModelBinders(myAssembly);
			builder.RegisterModelBinderProvider();
			builder.RegisterControllers(myAssembly);
			builder.RegisterAssemblyModules(myAssembly);
			
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			BundleTable.Bundles.RegisterTemplateBundles();
		}
	}
}