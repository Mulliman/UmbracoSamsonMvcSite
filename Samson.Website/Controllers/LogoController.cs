using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Services;
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
            return View("~/Views/Partials/LogoView.cshtml", new LogoModel { Url = "http://google.com" });
        }
    }
}
