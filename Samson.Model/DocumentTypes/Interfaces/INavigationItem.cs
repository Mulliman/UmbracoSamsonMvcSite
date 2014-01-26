namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface INavigationItem
    {
        string NavigationTitle { get; set; }

        string NavigationClass { get; set; }

        bool ShowInNavigation { get; set; }

        string Url { get; set; }
    }
}