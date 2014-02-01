using System;
using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Article")]
    public class Article : Page, IArticle
    {
        public override void SetCustomFields()
        {
            Summary = GetPropertyValue<string>("summary");
            ArticleImageId = GetPropertyValue<int>("articleImageId");
            DisplayDateTime = GetFirstNonDefaultValue(
                    GetPropertyValue<DateTime>("displayDateTime"),
                    CreateDate
                );
                
            var tags = GetPropertyValue<string>("tags");
            
            Tags = !string.IsNullOrWhiteSpace(tags) && tags.Contains(",")
                ? tags.Split(new [] {","}, StringSplitOptions.RemoveEmptyEntries)
                : new string[0];

            base.SetCustomFields();
        }

        public string Summary { get; set; }

        public int ArticleImageId { get; set; }

        public DateTime DisplayDateTime { get; set; }

        public IList<string> Tags { get; set; }
    }
}
