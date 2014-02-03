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
        private const string TagSearchQueryStringKey = "tag";

        private readonly IBlogRepository _blogRepository;
        private readonly IStrongContentService _strongContentService;

        public BlogController(IBlogRepository repo, IStrongContentService contentService)
        {
            _blogRepository = repo;
            _strongContentService = contentService;
        }

        public ActionResult ShowBlogArticlesListing()
        {
            var blogHub = _strongContentService.GetCurrentNode<IBlogHub>();

            if(blogHub == null || blogHub.HideListing)
            {
                // This is not a blog hub, so can't have this listing.
                return null;
            }

            var articles = _blogRepository.GetAllBlogArticles(blogHub.Id);

            var map = AutoMapper.Mapper.CreateMap<IBlogArticle, BlogArticle>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<BlogArticle>);

            var model = new BlogArticlesModel
            {
                BlogArticles = articleModels
            };

            return View("~/Views/Partials/BlogArticlesListingView.cshtml", model);
        }

        public ActionResult ShowBlogTagsListing()
        {
            var blogHub = _blogRepository.GetMainBlogHub();

            if (blogHub == null)
            {
                // No blog?!?
                return null;
            }

            var tags = _blogRepository.GetAllTags();

            var model = new TagsModel
            {
                Tags = tags,
                HubUrlWithTagQueryString = blogHub.Url + "?" + TagSearchQueryStringKey + "="
            };

            return View("~/Views/Partials/TagsListingView.cshtml", model);
        }
    }
}
