using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samson.Website.Models.PartialModels
{
    public class ListingItem
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string NavigationTitle { get; set; }

        public bool HideFromParentListing { get; set; }

        public string Summary { get; set; }

        public int ArticleImageId { get; set; }

        public IList<string> Tags { get; set; }
    }
}