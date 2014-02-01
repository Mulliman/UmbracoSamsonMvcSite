using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Hub")]
    public class Hub : Page, IHub
    {
        public override void SetCustomFields()
        {
            ShowListing = GetPropertyValue<bool>("showListing");
            UsePaging = GetPropertyValue<bool>("usePaging");
            AmountPerPage = GetPropertyValue<int>("amountPerPage");

            base.SetCustomFields();
        }

        public bool ShowListing { get; set; }

        public bool UsePaging { get; set; }

        public int AmountPerPage { get; set; }
    }
}