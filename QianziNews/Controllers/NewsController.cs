using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QianziNews.Data;
using QianziNews.Models.NewsViewModels;



namespace QianziNews.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public NewsController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            IEnumerable<News> news = _dbContext.News.ToList();
            NewsIndexViewModel model = new NewsIndexViewModel(news, 10, page);
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int Id, string returnUrl)
        {
            var news = await _dbContext.News.Include(n => n.Detail).SingleAsync(p => p.Id == Id);
            if (news != null)
            {
                if (news.Detail == null) news.Detail = new NewsDetail();
                news.Detail.ClickCount++;
                _dbContext.SaveChangesAsync().Wait();
                news.Content = TextManage.ToHtml(news.Content);
                DetailViewModel detailViewModel = new DetailViewModel { News = news };
                return View(detailViewModel);
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult AddNews()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddNews(News news, List<IFormFile> files)
        {

            if (ModelState.IsValid)
            {
                if (_dbContext.News.Where(p => p.Title.Equals(news.Title)).Count() == 0)
                {
                    if (files.Count() > 0)
                    {
                        news.Images = new List<NewsImage>();
                        foreach (var f in files)
                        {
                            news.Images.Add(new NewsImage { Url = f.FileName, NewsId = news.Id, MimeType = f.ContentType });
                        }

                    }
                    string upPath = Path.Combine(_env.WebRootPath, "images");
                    MyFile.Up(upPath, files).Wait();
                    _dbContext.News.Add(news);
                    await _dbContext.SaveChangesAsync();
                    TempData["Message"] = "添加成功!";
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["errorMessage"] = "添加失败!";
            return View(news);
        }

        [AllowAnonymous]
        //public IActionResult DelNews()
        //{
        //    return RedirectToAction("Index");
        //}

        public IActionResult DelNews()
        {
            var allblogs = _dbContext.News.ToArrayAsync();
            _dbContext.News.RemoveRange(allblogs.Result);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }


        [AllowAnonymous]
        public async Task<IActionResult> DeleteNews(int Id)
        {
            var news = _dbContext.News.Single(p => p.Id == Id);
            if (news != null)
            {
                List<string> paths = new List<string>();
                foreach (string i in await GetImageUrl(Id))
                {
                    paths.Add(Path.Combine(_env.WebRootPath, i));
                }
                MyFile.Remove(paths);
                _dbContext.News.Remove(news);
                await _dbContext.SaveChangesAsync();
                ViewData["Message"] = "删除成功!";
                return RedirectToAction("Index");
            }
            ViewData["errorMessage"] = "指定删除的新闻不存在!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> EditNews(int Id)
        {
            var news = await _dbContext.News.Include(n => n.Images).SingleOrDefaultAsync(p => p.Id == Id);
            if (news != null)
            {
                //EditViewModel editViewModel = new EditViewModel { News = news };
                return View(news);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EditNews(News news, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                News item = await _dbContext.News.Include(p => p.Images).SingleOrDefaultAsync(p => p.Id == news.Id);
                //修改新闻信息
                if (item != null)
                {
                    if (files.Count() > 0)
                    {
                        news.Images = new List<NewsImage>();
                        foreach (var f in files)
                        {
                            news.Images.Add(new NewsImage { Url = f.FileName, NewsId = news.Id, MimeType = f.ContentType });
                        }

                    }
                    //上传的图片文件夹路径
                    string upPath = Path.Combine(_env.WebRootPath, "images");
                    //原图片路径
                    List<string> paths = new List<string>();
                    foreach (string i in await GetImageUrl(item.Id))
                    {
                        paths.Add(Path.Combine(_env.WebRootPath, i));
                    }
                    //删除原图片并上传新图片
                    MyFile.Remove(paths);
                    MyFile.Up(upPath, files).Wait();
                    //保存修改后的新闻信息
                    item.CopyFrom(news);
                    await _dbContext.SaveChangesAsync();
                    TempData["Message"] = "编辑成功!";
                    return RedirectToAction("Index");
                }
            }
            return View(news);
        }



        [AllowAnonymous]
        public async Task<IEnumerable<string>> GetImageUrl(int Id)
        {
            List<NewsImage> image = await _dbContext.NewsImage.Where(p => p.NewsId == Id).ToListAsync();
            if (image == null) return null;
            List<string> urls = new List<string>();
            foreach (var i in image)
            {
                string path = Path.Combine("images", i.Url);
                urls.Add(path);
            }
            return urls;
        }
    }
}