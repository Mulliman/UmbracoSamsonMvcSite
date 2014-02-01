using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Website.Models.PartialModels;

namespace Samson.Website.Models
{
    public class ArticlesModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}