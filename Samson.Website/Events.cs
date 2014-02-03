using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Samson.Model.Caching;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace Samson.Website
{
    public class Events : ApplicationEventHandler
    {
        private readonly IKernel _kernel; 
        private readonly ICache _cache;

        public Events()
        {
            _kernel = new StandardKernel(new NinjectModule());
            _cache = _kernel.Get<ICache>();
        }

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Published += ContentService_Published;
        }

        public void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            // Super heavy handed cache clearing.
            _cache.Clear();
        }
    }
}