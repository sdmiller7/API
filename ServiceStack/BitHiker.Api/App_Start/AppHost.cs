using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Mvc;
using BitHiker.Api.Repositories;
using BitHiker.Api.Services;
using ServiceStack.Configuration;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof(BitHiker.Api.App_Start.AppHost), "Start")]

//IMPORTANT: Add the line below to MvcApplication.RegisterRoutes(RouteCollection) in the Global.asax:
//routes.IgnoreRoute("api/{*pathInfo}"); 

/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace BitHiker.Api.App_Start
{
	//A customizeable typed UserSession that can be extended with your own properties
	//To access ServiceStack's Session, Cache, etc from MVC Controllers inherit from ControllerBase<CustomUserSession>
	public class CustomUserSession : AuthUserSession
	{
		public string CustomProperty { get; set; }
	}

	public class AppHost
		: AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("StarterTemplate ASP.NET Host", typeof(ExchangeService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
		
			//Uncomment to change the default ServiceStack configuration
			//SetConfig(new EndpointHostConfig {
			//});

            ConfigureDatabases(container);

			//Enable Authentication
			ConfigureAuth(container);

			//Register all your dependencies
            container.Register(c => new ExchangeRepository(c.Resolve<IDbConnectionFactory>()));
		    container.Register(c => new PrototypeExchangeRepository(c.Resolve<IDbConnectionFactory>()));

            ConfigureTables(container);
            
			//Set MVC to use the same Funq IOC as ServiceStack
			ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
		}

        private void ConfigureDatabases(Funq.Container container)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;

            var dbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);

            container.Register<IDbConnectionFactory>(c => dbFactory);
        }

		// Uncomment to enable ServiceStack Authentication and CustomUserSession
		private void ConfigureAuth(Funq.Container container)
		{
			var appSettings = new AppSettings();

			//Default route: /auth/{provider}
			Plugins.Add(new AuthFeature(() => new CustomUserSession(),
				new IAuthProvider[] {
					new CredentialsAuthProvider(appSettings), 
					new FacebookAuthProvider(appSettings), 
					new TwitterAuthProvider(appSettings), 
					new BasicAuthProvider(appSettings), 
				})); 

			//Default route: /register
			Plugins.Add(new RegistrationFeature());

			container.Register<IUserAuthRepository>(c =>
				new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

			var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
			authRepo.CreateMissingTables();
		}

        private void ConfigureTables(Funq.Container container)
        {
            var exchangeRepo = container.Resolve<ExchangeRepository>();
            exchangeRepo.CreateMissingTables();

            var prototypeExchangeRepo = container.Resolve<PrototypeExchangeRepository>();
            prototypeExchangeRepo.CreateMissingTables();
        }

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}