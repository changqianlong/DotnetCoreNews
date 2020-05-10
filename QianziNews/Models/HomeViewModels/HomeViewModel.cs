using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QianziNews.Data;

namespace QianziNews.Models.HomeViewModels
{
    public class HomeViewModel
    {
        private readonly ApplicationDbContext _dbContext;
        private const int GroupNumber = 3;

        public IEnumerable<string> Categories { get; set; } = new string[] { "财经", "政治","体育","健康","科技","军事","旅游" };

        public IEnumerable<News> AllNews { get; set; }

        public IEnumerable<News> BannerNews { get; set; }

        public IEnumerable<TopNewsGroup> TopNewsGroup { get; set; }

        //public HotNewsGroup HotNewsGroup { get; set; }

        public CategoryNews CategoryNews { get; set; }

        public HomeViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Initial()
        {

            AllNews = await _dbContext.News.Include(n => n.Images).Include(n => n.Detail).OrderByDescending(n => n.Detail.ClickCount).AsNoTracking().ToListAsync();

            BannerNews = AllNews.Where(p => p.Images.Count()>0).Take(4);

            TopNewsGroup = new List<TopNewsGroup>();
            for (int i = 0; i < GroupNumber; i++)
            {
                TopNewsGroup group = new TopNewsGroup(AllNews.Skip(TopNewsGroup.Count()*3).Take(3));
                ((List<TopNewsGroup>)TopNewsGroup).Add(group);
            }
            //HotNewsGroup = new HotNewsGroup { ImageNews = AllNews.Where(p => p.Images.Count() > 0).Take(4),News = AllNews.Take(10) };

            CategoryNews = new CategoryNews { News = AllNews.Skip(TopNewsGroup.Count()*3) };

        }


    }
}
