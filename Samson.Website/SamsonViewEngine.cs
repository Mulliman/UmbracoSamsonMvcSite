using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samson.Website
{
    public class SamsonViewEngine : RazorViewEngine
    {
        private static string[] NewPartialViewFormats = new[] { 
            "~/Views/Partials/{0}.cshtml",
            "~/Views/Partials/{1}/{0}.cshtml",
            "~/Views/Shared/Partials/{0}.cshtml",
        };

        public SamsonViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }
    }
}