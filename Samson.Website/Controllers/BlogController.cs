using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Services;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class BlogController : SurfaceController
    {
        private readonly IBlogRepository _articlesRepository;
        private readonly IStrongContentService _strongContentService;

        public BlogController(IBlogRepository repo, IStrongContentService contentService)
        {
            _articlesRepository = repo;
            _strongContentService = contentService;
        }

        public ActionResult ShowBlogArticlesListing()
        {
            var blogHub = _strongContentService.GetCurrentNode<Samson.Model.DocumentTypes.BlogHub>();

            if(blogHub == null || blogHub.HideListing)
            {
                // This is not a blog hub, so can't have this listing.
                return null;
            }

            var articles = _articlesRepository.GetAllBlogArticles(blogHub.Id);

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
