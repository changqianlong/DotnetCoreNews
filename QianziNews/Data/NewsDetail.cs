using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QianziNews.Data
{
    public class NewsDetail
    {
        [Key]
        public int Id { get; set; }


        public int ClickCount { get; set; } = 0;

        public News News { get; set; }

        public int NewsId { get; set; }
    }
}
