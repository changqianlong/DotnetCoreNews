using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Data
{
    public class TopNewsGroup:IEnumerable<News>
    {
        public IEnumerable<News> News { get; set; }

        public TopNewsGroup(IEnumerable<News> news)
        {
            News = news;
        }

        public IEnumerator<News> GetEnumerator()
        {
            foreach(var n in News)
            {
                yield return n;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
