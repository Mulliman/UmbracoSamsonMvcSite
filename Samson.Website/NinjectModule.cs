using Samson.Model.Repositories;
using Samson.Model.Repositories.Interfaces;
using Samson.Services;
using Samson.Standard.Services;

namespace Samson.Website
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IStrongContentService>().To<StrongContentService>();
            Bind<IStrongMediaService>().To<StrongMediaService>();

            // Repositories
            Bind<IArticlesRepository>().To<ArticlesRepository>();
            Bind<IBlogRepository>().To<BlogRepository>();

            // Services
        }
    }
}