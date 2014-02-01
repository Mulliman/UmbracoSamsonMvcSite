using System.Collections.Generic;
using Samson.Website.Models.PartialModels;

namespace Samson.Website.Models
{
    public class NavigationModel
    {
        public IEnumerable<NavigationItem> NavigationItems { get; set; }
    }
}