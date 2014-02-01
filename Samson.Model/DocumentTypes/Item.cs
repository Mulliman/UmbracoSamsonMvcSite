using System;
using System.Collections.Generic;
using System.Linq;
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

        protected string GetFirstNonEmptyValue(params string[] strings)
        {
            return strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
        }

        protected DateTime GetFirstNonDefaultValue(params DateTime[] dateTimes)
        {
            return dateTimes.FirstOrDefault(d => d != default(DateTime));
        }
    }
}