using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Options;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Hub")]
    public class Hub : IHub
    {
        public bool ShowListing { get; set; }

        public bool UsePaging { get; set; }

        public int AmountPerPage { get; set; }

        public SortingOption SortingOption { get; set; }
    }
}