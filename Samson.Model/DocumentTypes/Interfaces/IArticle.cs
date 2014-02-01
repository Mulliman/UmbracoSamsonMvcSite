using System;
using System.Collections.Generic;
namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IArticle : IPage
    {
        string Summary { get; set; }

        int ArticleImageId { get; set; }

        DateTime DisplayDateTime { get; set; }

        IList<string> Tags { get; set; }
    }
}