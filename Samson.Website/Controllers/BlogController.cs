using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class BlogController : SurfaceController
    {
        private readonly IBlogRepository _articlesRepository;

        public BlogController(IBlogRepository repo)
        {
            _articlesRepository = repo;
        }

        public ActionResult GetAllBlogArticles(int currentPageId)
        {
            var articles = _articlesRepository.GetAllBlogArticles(currentPageId);

            var map = AutoMapper.Mapper.CreateMap<IBlogArticle, BlogArticle>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<BlogArticle>);

            var model = new BlogArticlesModel
            {
                BlogArticles = articleModels
            };

            return View("~/Views/Partials/BlogArticlesListingView.cshtml", model);
        }
    }
}
