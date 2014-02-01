namespace Samson.Website.Models.PartialModels
{
    public class BlogArticle : Article
    {
        public bool AllowNewComments { get; set; }

        public bool ShowComments { get; set; }
    }
}