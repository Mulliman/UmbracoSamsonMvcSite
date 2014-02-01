namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IHub
    {
        bool HideListing { get; set; }

        bool UsePaging { get; set; }

        int AmountPerPage { get; set; }
    }
}