using System.Linq;
using System.Web.Mvc;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.WebApi;

namespace Samson.Website.Api
{
    public class BlogController : UmbracoApiController
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository repo)
        {
            _blogRepository = repo;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [HttpGet]
        public BlogArticlesModel Index()
        {
            var articles = _blogRepository.GetAllBlogArticles();

            var map = AutoMapper.Mapper.CreateMap<IBlogArticle, BlogArticle>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<BlogArticle>);

            var model = new BlogArticlesModel
            {
                BlogArticles = articleModels
            };

            return model;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [HttpGet]
        public BlogArticlesModel Index(string tag)
        {
            var articles = _blogRepository.GetAllBlogArticlesWithTag(tag);

            var map = AutoMapper.Mapper.CreateMap<IBlogArticle, BlogArticle>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<BlogArticle>);

            var model = new BlogArticlesWithTagModel
            {
                BlogArticles = articleModels,
                Tag = tag
            };

            return model;
        }
    }
}
