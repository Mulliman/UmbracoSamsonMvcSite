using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Item")]
    public class Item : BasicContentItem
    {
        public override void SetCustomFields()
        {
            base.SetCustomFields();
        }
    }
}
