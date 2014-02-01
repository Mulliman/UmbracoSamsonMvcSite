using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;

namespace Samson.Website.Models
{
    public class ArticlesModel
    {
        public IEnumerable<IArticle> Articles { get; set; }
    }
}