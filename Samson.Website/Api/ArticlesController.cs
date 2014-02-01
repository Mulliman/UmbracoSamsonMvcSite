using System.Linq;
using System.Web.Http;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.WebApi;

namespace Samson.Website.Api
{
    public class ArticlesController : UmbracoApiController
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesController(IArticlesRepository repo)
        {
            _articlesRepository = repo;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [HttpGet]
        public ArticlesModel Index()
        {
            var articles = _articlesRepository.GetAllArticles();

            var map = AutoMapper.Mapper.CreateMap<IArticle, Article>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<Article>);

            var model = new ArticlesModel
            {
                Articles = articleModels
            };

            return model;
        }
    }
}