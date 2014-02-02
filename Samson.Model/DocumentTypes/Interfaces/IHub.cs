namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IHub : IPage
    {
        bool HideListing { get; set; }

        bool UsePaging { get; set; }

        int AmountPerPage { get; set; }
    }
}