using System;
using System.Collections.Generic;
namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IArticle : IPage
    {
        string PageTitle { get; set; }

        string Summary { get; set; }

        int ArticleImageId { get; set; }

        DateTime DisplayDateTime { get; set; }

        string Url { get; set; }

        IList<string> Tags { get; set; }
    }
}