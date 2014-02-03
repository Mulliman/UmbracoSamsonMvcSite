using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("ContentPage")]
    public class ContentPage : Page, IListablePage
    {
        public override void SetCustomFields()
        {
            Summary = GetPropertyValue<string>("summary");
            ArticleImageId = GetPropertyValue<int>("articleImageId");

            var tags = GetPropertyValue<string>("tags");

            Tags = !string.IsNullOrWhiteSpace(tags)
                ? GetTags(tags)
                : new string[0];

            base.SetCustomFields();
        }

        public string Summary { get; set; }

        public int ArticleImageId { get; set; }

        public IList<string> Tags { get; set; }

        private IList<string> GetTags(string tags)
        {
            return tags.Contains(",")
                ? tags.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                : new string[] { tags };
        }
    }
}