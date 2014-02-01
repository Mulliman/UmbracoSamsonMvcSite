using System.Collections.Generic;
using System.Linq;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Services;

namespace Samson.Model.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly IStrongContentService _strongContentService;

        public ArticlesRepository(IStrongContentService strongContentService)
        {
            _strongContentService = strongContentService;
        }

        public IEnumerable<IArticle> GetAllArticles()
        {
            var root = _strongContentService.GetRootNodes().First();

            return _strongContentService.GetDescendantNodes<Article>(root);
        }

        public IEnumerable<IArticle> GetAllArticles(Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllArticles();

            return sorter.Sort<IArticle>(nodes);
        }

        public IEnumerable<IArticle> GetAllArticles(int parentNodeId)
        {
            return _strongContentService.GetDescendantNodes<Article>(parentNodeId);
        }

        public IEnumerable<IArticle> GetAllArticles(int parentNodeId, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllArticles(parentNodeId);

            return sorter.Sort<IArticle>(nodes);
        }

        public IEnumerable<IArticle> GetPageOfArticles(int startIndex, int pageSize)
        {
            var nodes = GetAllArticles();

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IArticle> GetPageOfArticles(int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllArticles();

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IArticle> GetPageOfArticles(int parentNodeId, int startIndex, int pageSize)
        {
            var nodes = GetAllArticles(parentNodeId);

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IArticle> GetPageOfArticles(int parentNodeId, int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllArticles(parentNodeId);

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Skip(startIndex).Take(pageSize);
        }
    }
}
