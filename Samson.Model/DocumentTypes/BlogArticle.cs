using System.Threading.Tasks;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("BlogArticle")]
    public class BlogArticle : Article, IBlogArticle
    {
        public bool AllowNewComments { get; set; }

        public bool ShowComments { get; set; }
    }
}
