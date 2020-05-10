using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QianziNews.Data;
using QianziNews.Models;
using QianziNews.Models.HomeViewModels;

namespace QianziNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;


        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel(_dbContext);
            await homeViewModel.Initial();

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Category(string category)
        {
            var news = _dbContext.News.Include(n => n.Images).Where(n => n.Category == category).ToList();
            var banners = news.Where(n => n.Images.Count() > 0).Take(4);
            CategoryViewModel model = new CategoryViewModel { BannerNews = banners, News = news };
            ViewData["Title"] = category;
            return View(model);
        }

        public IActionResult Search(string title)
        {
            var news = _dbContext.News.Where(n => n.Title.Contains(title)).ToList();
            return View();
        }
    }
}
