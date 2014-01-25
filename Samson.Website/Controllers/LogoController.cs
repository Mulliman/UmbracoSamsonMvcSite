using System.Linq;
using System.Web.Mvc;
using Samson.Services;
using Samson.Standard.MediaTypes;
using Samson.Standard.Mvc;
using Samson.Website.Models;

namespace Samson.Website.Controllers
{
    public class LogoController : SamsonSurfaceController
    {
        public LogoController(IStrongContentService contentService, IStrongMediaService mediaService)
            : base(contentService, mediaService)
        {
        }

        public ActionResult Index()
        {
            var firstRoot = StrongContentService.GetRootNodes().First();

            var siteSettingsNode = firstRoot as Samson.Model.DocumentTypes.Website;

            if(siteSettingsNode == null || siteSettingsNode.LogoId == 0)
            {
                // No Logo settings set up.
                return null;
            }

            var logoImage = StrongMediaService.GetMediaItem<Image>(siteSettingsNode.LogoId);

            var logoModel = new LogoModel 
            { 
                Url =  "/",
                Image = logoImage
            };

            return View("~/Views/Partials/LogoView.cshtml", logoModel);
        }
    }
}
