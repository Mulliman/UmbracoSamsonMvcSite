using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Page")]
    public class Page : Item, IPage
    {
        public string PageTitle { get; set; }

        public string MainContent { get; set; }

        public string NavigationTitle { get; set; }

        public string NavigationClass { get; set; }

        public bool ShowInNavigation { get; set; }

        public bool HideFromParentListing { get; set; }
    }
}
