using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("ConfigurationItem")]
    public class ConfigurationItem : Item, IConfigurationItem
    {
        public string Value { get; set; }
    }
}