using System.Collections.Generic;
using System.Linq;
using Samson.Model.Caching;
using Samson.Model.DocumentTypes;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Services;

namespace Samson.Model.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IStrongContentService _strongContentService;
        private readonly ICache _cache;

        public BlogRepository(IStrongContentService strongContentService, ICache cache)
        {
            _strongContentService = strongContentService;
            _cache = cache;
        }

        public IBlogHub GetMainBlogHub()
        {
            const string cachingKey = "Blog.MainHub";

            if (_cache.Contains(cachingKey))
            {
                return _cache.Retrieve<IBlogHub>(cachingKey);
            }

            var root = _strongContentService.GetRootNodes().First();

            var blogHub = _strongContentService.GetChildNodes<IBlogHub>(root).FirstOrDefault();

            blogHub = blogHub ?? _strongContentService.GetDescendantNodes<IBlogHub>(root).FirstOrDefault();

            if (blogHub != null)
            {
                _cache.Add(cachingKey, blogHub);
            }
            
            return blogHub;
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles()
        {
            const string cachingKey = "Blog.AllArticles";

            if (_cache.Contains(cachingKey))
            {
                return _cache.Retrieve<IEnumerable<IBlogArticle>>(cachingKey);
            }

            var root = _strongContentService.GetRootNodes().First();

            var articles = _strongContentService.GetDescendantNodes<IBlogArticle>(root);

            _cache.Add(cachingKey, articles);
            return articles;
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles(Sorting.Interfaces.ISorter sorter)
        {
            var nodes = GetAllBlogArticles();

            return sorter.Sort<IBlogArticle>(nodes);
        }

        public IEnumerable<IBlogArticle> GetAllBlogArticles(int parentNodeId)
        {
            return _strongContentService.GetDescendantNodes<IBlogArticle>(parentNodeId);
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
            string cachingKey = "Blog.ArticlesWithTag." + tag;

            if (_cache.Contains(cachingKey))
            {
                return _cache.Retrieve<IEnumerable<IBlogArticle>>(cachingKey);
            }

            var nodes = GetAllBlogArticles();
            nodes = nodes.Where(b => b.Tags.Contains(tag));

            _cache.Add(cachingKey, nodes);
            return nodes;
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

        public IEnumerable<string> GetAllTags()
        {
            const string cachingKey = "Blog.AllTags";

            if (_cache.Contains(cachingKey))
            {
                return _cache.Retrieve<IEnumerable<string>>(cachingKey);
            }

            var articles = GetAllBlogArticles();

            var tags = articles.SelectMany(a => a.Tags).Distinct();

            _cache.Add(cachingKey, tags);
            return tags;
        }

        public IEnumerable<string> GetAllTags(int parentNodeId)
        {
            string cachingKey = string.Format("Blog.AllTags.{0}", parentNodeId);

            if (_cache.Contains(cachingKey))
            {
                return _cache.Retrieve<IEnumerable<string>>(cachingKey);
            }

            var articles = GetAllBlogArticles(parentNodeId);

            var tags = articles.SelectMany(a => a.Tags).Distinct();

            _cache.Add(cachingKey, tags);
            return tags;
        }
    }
}
