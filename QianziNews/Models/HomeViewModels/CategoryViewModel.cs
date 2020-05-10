using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QianziNews.Data;

namespace QianziNews.Models.HomeViewModels
{
    public class CategoryViewModel
    {
        public string Banner { get; set; }

        public IEnumerable<News> News { get; set; }

        public IEnumerable<News> BannerNews { get; set; }

        public CategoryViewModel() { }

    }

}
