using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samson.Website.Models.PartialModels;

namespace Samson.Website.Models
{
    public class BlogArticlesModel
    {
        public IEnumerable<BlogArticle> BlogArticles { get; set; }

        public bool ShowChildListing { get; set; }
    }
}