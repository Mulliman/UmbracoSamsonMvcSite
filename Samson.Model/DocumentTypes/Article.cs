using System;
using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Standard.DocumentTypes;

namespace Samson.Model.DocumentTypes
{
    [DocumentTypeAlias("Article")]
    public class Article : ContentPage, IArticle, IDateSortable
    {
        public override void SetCustomFields()
        {
            DisplayDateTime = GetFirstNonDefaultValue(
                    GetPropertyValue<DateTime>("displayDateTime"),
                    CreateDate
                );

            base.SetCustomFields();
        }

        public DateTime DisplayDateTime { get; set; }

        public DateTime GetSortingDate()
        {
            return DisplayDateTime;
        }
    }
}