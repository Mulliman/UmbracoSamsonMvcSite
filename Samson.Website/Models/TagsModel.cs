using System.Collections.Generic;

namespace Samson.Website.Models
{
    public class TagsModel
    {
        public IEnumerable<string> Tags { get; set; }

        public string HubUrlWithTagQueryString { get; set; }
    }
}