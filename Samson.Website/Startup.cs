using System.Reflection;
using System.Web.Mvc;
using Ninject;
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

            ControllerBuilder.Current.SetControllerFactory(
                new Samson.Mvc.Ninject.NinjectControllerFactory(new StandardKernel(new NinjectModule()))
            );
        }
    }
}