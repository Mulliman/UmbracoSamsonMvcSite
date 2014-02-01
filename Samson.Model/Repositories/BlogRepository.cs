using System.Collections.Generic;
using System.Linq;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Services;

namespace Samson.Model.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IStrongContentService _strongContentService;

        public BlogRepository(IStrongContentService strongContentService)
        {
            _strongContentService = strongContentService;
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles()
        {
            var root = _strongContentService.GetRootNodes().First();

            return _strongContentService.GetDescendantNodes<BlogArticle>(root);
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles(Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles();

            return sorter.Sort<IBlogArticle>(nodes);
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles(int parentNodeId)
        {
            return _strongContentService.GetDescendantNodes<BlogArticle>(parentNodeId);
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles(int parentNodeId, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            return sorter.Sort<IBlogArticle>(nodes);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticles(int startIndex, int pageSize)
        {
            var nodes = GetAllBlogArticles();

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticles(int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles();

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticles(int parentNodeId, int startIndex, int pageSize)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticles(int parentNodeId, int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag)
        {
            var nodes = GetAllBlogArticles();

            return nodes.Where(b => b.Tags.Contains(tag));
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles();

            var sortedNodes = sorter.Sort(nodes);

            return sortedNodes.Where(b => b.Tags.Contains(tag));
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, int parentNodeId)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            return nodes.Where(b => b.Tags.Contains(tag));
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, int parentNodeId, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            var sortedNodes = sorter.Sort(nodes);

            return sortedNodes.Where(b => b.Tags.Contains(tag));
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int startIndex, int pageSize)
        {
            var nodes = GetAllBlogArticles();

            return nodes.Where(b => b.Tags.Contains(tag)).Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles();

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Where(b => b.Tags.Contains(tag)).Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int parentNodeId, int startIndex, int pageSize)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            return nodes.Where(b => b.Tags.Contains(tag)).Skip(startIndex).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int parentNodeId, int startIndex, int pageSize, Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles(parentNodeId);

            var sortedNodes = sorter.Sort(nodes);

            return nodes.Where(b => b.Tags.Contains(tag)).Skip(startIndex).Take(pageSize);
        }
    }
}
