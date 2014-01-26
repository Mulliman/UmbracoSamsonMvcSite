using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("blogHub")]
    public class BlogHub : Hub, IBlogHub
    {
    }
}
