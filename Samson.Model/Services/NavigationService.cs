using System.Collections.Generic;
using System.Linq;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Services.Interfaces;
using Samson.Services;

namespace Samson.Model.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IStrongContentService _contentService;

        public NavigationService(IStrongContentService service)
        {
            _contentService = service;
        }

        public IEnumerable<IPage> GetTopLevelNavigationPages()
        {
            var root = _contentService.GetRootNodes().First();

            return _contentService.GetChildNodes<Page>(root).Where(p => p.ShowInNavigation);
        }
    }
}
