﻿using System.Linq;
using System.Web.Mvc;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Repositories.Interfaces;
using Samson.Website.Models;
using Samson.Website.Models.PartialModels;
using Umbraco.Web.Mvc;

namespace Samson.Website.Controllers
{
    public class ArticlesController : SurfaceController
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesController(IArticlesRepository repo)
        {
            _articlesRepository = repo;
        }

        public ActionResult ShowAllArticles()
        {
            var articles = _articlesRepository.GetAllArticles();

            var map = AutoMapper.Mapper.CreateMap<IArticle, Article>();
            var articleModels = articles.Select(AutoMapper.Mapper.Map<Article>);

            var model = new ArticlesModel
            {
                Articles = articleModels
            };

            return View("~/Views/Partials/ArticlesListingView.cshtml", model);
        }
    }
}