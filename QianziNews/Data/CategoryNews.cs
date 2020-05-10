using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Data
{
    public class CategoryNews
    {

        public News Header { get; set; }

        public IEnumerable<News> News { get; set; }

        public CategoryNews()
        {
            
        }

    }
}
