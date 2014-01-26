using Samson.Model.Options;

namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IHub
    {
        bool ShowListing { get; set; }

        bool UsePaging { get; set; }

        int AmountPerPage { get; set; }

        SortingOption SortingOption { get; set; }
    }
}
