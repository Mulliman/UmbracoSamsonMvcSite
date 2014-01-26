namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IBlogArticle : IArticle
    {
        bool AllowNewComments { get; set; }

        bool ShowComments { get; set; }
    }
}
