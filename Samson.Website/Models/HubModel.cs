using System.Collections.Generic;
using Samson.Website.Models.PartialModels;

namespace Samson.Website.Models
{
    public class HubModel
    {
        public IEnumerable<ListingItem> Pages { get; set; } 
    }
}