using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("ConfigurationItem")]
    public class ConfigurationItem : Item, IConfigurationItem
    {
        public override void SetCustomFields()
        {
            Value = GetPropertyValue<string>("value");

            base.SetCustomFields();
        }

        public string Value { get; set; }
    }
}