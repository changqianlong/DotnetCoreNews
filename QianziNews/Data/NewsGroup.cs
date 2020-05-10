using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Data
{
    public class NewsGroup
    {
        private News _image;
        private IEnumerable<News> _news;

        public virtual News Image { get => _image; set => _image = value; }
        public virtual IEnumerable<News> News { get => _news; set => _news = value; }

        public NewsGroup()
        {

        }
    }
}
