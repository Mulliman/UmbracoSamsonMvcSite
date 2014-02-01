using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Website")]
    public class Website : BasicContentItem
    {
        public override void SetCustomFields()
        {
            base.SetCustomFields();

            LogoId = GetPropertyValue<int>("logo");
        }

        public int LogoId { get; set; }
    }
}