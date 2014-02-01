using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Page")]
    public class Page : Item, IPage
    {
        public override void SetCustomFields()
        {
            PageTitle = GetPropertyValue<string>("pageTitle");
            MainContent = GetPropertyValue<string>("mainContent");

            NavigationTitle = GetFirstNonEmptyValue(
                GetPropertyValue<string>("navigationTitle"),
                Name
            );

            NavigationClass = GetPropertyValue<string>("navigationClass");
            ShowInNavigation = GetPropertyValue<bool>("showInNavigation");
            HideFromParentListing = GetPropertyValue<bool>("hideFromParentListing");

            base.SetCustomFields();
        }

        public string PageTitle { get; set; }

        public string MainContent { get; set; }

        public string NavigationTitle { get; set; }

        public string NavigationClass { get; set; }

        public bool ShowInNavigation { get; set; }

        public bool HideFromParentListing { get; set; }
    }
}
