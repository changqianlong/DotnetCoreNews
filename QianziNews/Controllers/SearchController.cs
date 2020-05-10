using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QianziNews.Data;
using QianziNews.Models.SearchViewModels;

namespace QianziNews.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string str)
        {
            IEnumerable<News> result = _dbContext.News.Where(n => n.Title.Contains(str)).ToList();
            SearchViewModel model = new SearchViewModel();
            model.News = result;
            model.SearchString = str;
            return View(model);
        }
    }
}