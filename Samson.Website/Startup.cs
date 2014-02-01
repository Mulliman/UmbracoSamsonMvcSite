using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using Ninject;
using Samson.Mvc.Ninject;
using Samson.Standard;
using Samson.Standard.DocumentTypes;
using Samson.Standard.MediaTypes;
using Samson.Standard.Services;
using Umbraco.Core;

namespace Samson.Website
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            const string AssemblyLocation = "Samson.Model";
            var assembly = Assembly.Load(AssemblyLocation);

            SamsonContext.Current.DocumentTypesProvider = new AttributeDocumentTypeProvider(assembly);
            SamsonContext.Current.StrongContentService = new StrongContentService();

            SamsonContext.Current.MediaTypesProvider = new AttributeMediaTypeProvider(assembly);
            SamsonContext.Current.StrongMediaService = new StrongMediaService();

            // ControllerBuilder.Current.SetControllerFactory(
            //     new Samson.Standard.Mvc.StandardSamsonControllerFactory()
            //);

            var kernel = new StandardKernel(new NinjectModule());

            ControllerBuilder.Current.SetControllerFactory(
                new Samson.Mvc.Ninject.NinjectControllerFactory(kernel)
            );

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new NinjectWebApiControllerFactory(kernel));

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
        }
    }
}