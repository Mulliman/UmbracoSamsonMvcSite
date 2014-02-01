using System.Threading.Tasks;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("BlogArticle")]
    public class BlogArticle : Article, IBlogArticle
    {
        public override void SetCustomFields()
        {
            base.SetCustomFields();

            AllowNewComments = GetPropertyValue<bool>("allowNewComments");
            ShowComments = GetPropertyValue<bool>("showComments");
        }

        public bool AllowNewComments { get; set; }

        public bool ShowComments { get; set; }
    }
}
