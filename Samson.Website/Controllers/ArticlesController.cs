using System.Web.Mvc;
using Samson.Model.Repositories.Interfaces;
using Samson.Website.Models;
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
            var model = new ArticlesModel
            {
                Articles = _articlesRepository.GetAllArticles()
            };

            return View("~/Views/Partials/ArticlesListingView.cshtml", model);
        }
    }
}