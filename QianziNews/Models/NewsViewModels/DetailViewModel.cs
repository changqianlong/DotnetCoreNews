using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using QianziNews.Data;

namespace QianziNews.Models.NewsViewModels
{
    public class DetailViewModel
    {
        public News News { get; set; }

        public string Content { get; set; }

    }
}
