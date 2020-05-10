using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QianziNews.Data;

namespace QianziNews.Models.CommentViewModels
{
    public class CommentViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public int PageCounts { get; set; }
        public int HotPerPageCounts { get; set; } 
        public int LatestPerPageCounts { get; set; }

        public News News { get; set; }

        public IEnumerable<Comment> HotComments { get; set; }

        public IEnumerable<Comment> LatestComments { get; set; }

        public CommentViewModel()
        {

        }

        public CommentViewModel(IEnumerable<Comment> comments)
        {

        }

        public void Intial(IEnumerable<Comment> comments)
        {
            PageCounts = comments.Count() / LatestPerPageCounts+1;
            this.HotComments = comments.OrderByDescending(c => c.Zan).Take(HotPerPageCounts);
            this.LatestComments = comments.OrderByDescending(c => c.PostTime);
        }
    }
}
