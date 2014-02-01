using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Sorting.Interfaces;

namespace Samson.Model.Repositories.Interfaces
{
    public interface IArticlesRepository
    {
        IEnumerable<IArticle> GetAllArticles();

        IEnumerable<IArticle> GetAllArticles(ISorter sorter);

        IEnumerable<IArticle> GetAllArticles(int parentNodeId);

        IEnumerable<IArticle> GetAllArticles(int parentNodeId, ISorter sorter);

        IEnumerable<IArticle> GetPageOfArticles(int startIndex, int pageSize);

        IEnumerable<IArticle> GetPageOfArticles(int startIndex, int pageSize, ISorter sorter);

        IEnumerable<IArticle> GetPageOfArticles(int parentNodeId, int startIndex, int pageSize);

        IEnumerable<IArticle> GetPageOfArticles(int parentNodeId, int startIndex, int pageSize, ISorter sorter);
    }
}