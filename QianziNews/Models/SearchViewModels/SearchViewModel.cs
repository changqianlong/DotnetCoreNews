using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QianziNews.Data;

namespace QianziNews.Models.SearchViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<News> News { get; set; }

        public string SearchString { get; set; }
    }
}
