using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samson.Website.Models.PartialModels
{
    public class NavigationItem
    {
        public string NavigationTitle { get; set; }

        public string Url { get; set; }

        public string NavigationClass { get; set; }

        public bool IsActive { get; set; }
    }
}