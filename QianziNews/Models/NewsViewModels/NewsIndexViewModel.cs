using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QianziNews.Data;

namespace QianziNews.Models.NewsViewModels
{
    public class NewsIndexViewModel
    {
        public IEnumerable<News> News { get; set; }

        public int PageCounts { get; set; }

        public int PerPageCounts { get; set; }

        public int CurrentPage { get; set; }

        public NewsIndexViewModel(IEnumerable<News> news,int counts,int page)
        {
            News = news;
            CurrentPage = page;
            PerPageCounts = counts;
            PageCounts = News.Count() / PerPageCounts+1;
        }
    }
}
