using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;

namespace Samson.Website
{
    public class Startup : ApplicationEventHandler
    {
        //protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        //{
        //    SamsonContext.Current.DocumentTypesProvider = new AttributeDocumentTypeProvider(Assembly.GetExecutingAssembly());
        //    //SamsonContext.Current.DocumentTypesProvider.RegisterModelTypes(modelTypes);
        //    SamsonContext.Current.StrongContentService = new StrongContentService();

        //    SamsonContext.Current.MediaTypesProvider = new AttributeMediaTypeProvider(Assembly.GetExecutingAssembly());
        //    //SamsonContext.Current.MediaTypesProvider.RegisterModelTypes(mediaModelTypes);
        //    SamsonContext.Current.StrongMediaService = new StrongMediaService();

        //    ControllerBuilder.Current.SetControllerFactory(
        //        new Samson.Standard.Mvc.StandardSamsonControllerFactory()
        //   );
        //}
    }
}