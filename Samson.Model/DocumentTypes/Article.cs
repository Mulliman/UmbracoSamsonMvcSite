using System;
using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("article")]
    public class Article : Page, IArticle
    {
        public string Summary { get; set; }

        public int ArticleImageId { get; set; }

        public DateTime DisplayDateTime { get; set; }

        public IList<string> Tags { get; set; }
    }
}
