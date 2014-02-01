using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Sorting.Interfaces;

namespace Samson.Model.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<IBlogArticle> GetAllBlogArticles();

        IEnumerable<IBlogArticle> GetAllBlogArticles(ISorter sorter);

        IEnumerable<IBlogArticle> GetAllBlogArticles(int parentNodeId);

        IEnumerable<IBlogArticle> GetAllBlogArticles(int parentNodeId, ISorter sorter);

        IEnumerable<IBlogArticle> GetPageOfBlogArticles(int startIndex, int pageSize);

        IEnumerable<IBlogArticle> GetPageOfBlogArticles(int startIndex, int pageSize, ISorter sorter);

        IEnumerable<IBlogArticle> GetPageOfBlogArticles(int parentNodeId, int startIndex, int pageSize);

        IEnumerable<IBlogArticle> GetPageOfBlogArticles(int parentNodeId, int startIndex, int pageSize, ISorter sorter);

        IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag);

        IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, ISorter sorter);

        IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, int parentNodeId);

        IEnumerable<IBlogArticle> GetAllBlogArticlesWithTag(string tag, int parentNodeId, ISorter sorter);

        IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int startIndex, int pageSize);

        IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int startIndex, int pageSize, ISorter sorter);

        IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int parentNodeId, int startIndex, int pageSize);

        IEnumerable<IBlogArticle> GetPageOfBlogArticlesWithTag(string tag, int parentNodeId, int startIndex, int pageSize, ISorter sorter);
    }
}
