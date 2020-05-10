using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QianziNews.Data;
using QianziNews.Models.CommentViewModels;

namespace QianziNews.Controllers
{
    public class CommnetController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private const int HotPerPageCounts = 5;
        private const int LatestPerPageCounts = 15;


        public CommnetController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int id, int page = 1)
        {
            CommentViewModel model = new CommentViewModel();
            News news = await _dbContext.News.Include(n => n.Comments).AsNoTracking().SingleOrDefaultAsync(n => n.Id == id);
            if (news != null)
            {
                model.News = news;
                model.CurrentPage = page;
                model.HotPerPageCounts = HotPerPageCounts;
                model.LatestPerPageCounts = LatestPerPageCounts;
                model.Intial(news.Comments);

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int Id, string Content, string returnUrl)
        {
            if (string.IsNullOrEmpty(Content) || Content.Length == 0) return Redirect(returnUrl);
            News news = _dbContext.News.SingleOrDefault(n => n.Id == Id);
            if (news != null)
            {
                if (news.Comments == null) news.Comments = new List<Comment>();
                news.Comments.Add(new Comment { Content = Content, UserName = User.Identities.First().Name, PostTime = DateTime.Now });
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "发表评论成功!";
            }
            return Redirect(returnUrl);
        }


        public async Task<IActionResult> Zan(int Id)
        {
            Comment comment = await _dbContext.Comment.Include(c => c.News).SingleOrDefaultAsync(c => c.Id == Id);
            if (comment != null)
            {
                comment.Zan++;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = comment.News.Id });
        }
    }
}