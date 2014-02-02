using System.Linq;
using System.Web.Mvc;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Services;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class HubController : SurfaceController
    {
        private readonly IStrongContentService _strongContentService;

        public HubController(IStrongContentService contentService)
        {
            _strongContentService = contentService;
        }

        public ActionResult ShowHubListing()
        {
            var hub = _strongContentService.GetCurrentNode<Hub>();

            if(hub == null || hub.HideListing)
            {
                // This is not a hub, so can't have a listing.
                return null;
            }

            var pages = _strongContentService.GetChildNodes<ContentPage>(hub).Where(p => !p.HideFromParentListing);

            var map = AutoMapper.Mapper.CreateMap<IListablePage, ListingItem>();
            var pageModels = pages.Select(AutoMapper.Mapper.Map<ListingItem>);

            var model = new HubModel
            {
                Pages = pageModels
            };

            return View("~/Views/Partials/HubListingView.cshtml", model);
        }
    }
}