using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Services;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class NavigationController : SurfaceController
    {
        private readonly IStrongContentService _contentService;

        public NavigationController(IStrongContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult PrimaryNavigation()
        {
            var root = _contentService.GetRootNodes().First();

            var navPages =  _contentService.GetChildNodes<Page>(root).Where(p => p.ShowInNavigation);

            var navModel = new NavigationModel
            {
                NavigationItems = navPages.Select(CreateNavigationItem)
            };

            return View("~/Views/Partials/PrimaryNavigationView.cshtml", navModel);
        }

        public ActionResult ChildNavigation()
        {
            var current = _contentService.GetCurrentNode();

            var navPages = _contentService.GetChildNodes<Page>(current).Where(p => !p.HideFromParentListing);

            var navModel = new NavigationModel
            {
                NavigationItems = navPages.Select(CreateNavigationItem)
            };

            return View("~/Views/Partials/ChildNavigationView.cshtml", navModel);
        }

        private NavigationItem CreateNavigationItem(IPage page)
        {
            return new NavigationItem
            {
                NavigationClass = page.NavigationClass,
                NavigationTitle = page.NavigationTitle,
                Url = page.Url,
                // This one isn't implemented yet
                IsActive = false
            };
        }
    }
}
