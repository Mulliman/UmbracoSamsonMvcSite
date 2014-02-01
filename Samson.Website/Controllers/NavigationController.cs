using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Services.Interfaces;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class NavigationController : SurfaceController
    {
        private readonly INavigationService _navigationService;

        public NavigationController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ActionResult PrimaryNavigation()
        {
            var navPages = _navigationService.GetTopLevelNavigationPages();

            var navModel = new NavigationModel
            {
                NavigationItems = navPages.Select(CreateNavigationItem)
            };

            return View("~/Views/Partials/PrimaryNavigationView.cshtml", navModel);
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
