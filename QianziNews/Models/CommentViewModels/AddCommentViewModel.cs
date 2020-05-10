using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QianziNews.Data;

namespace QianziNews.Models.CommentViewModels
{
    public class AddCommentViewModel
    {
        public int Id { get; set; }

        public string ReturnUrl { get; set; }

        public Comment Comment { get; set; }
    }
}
