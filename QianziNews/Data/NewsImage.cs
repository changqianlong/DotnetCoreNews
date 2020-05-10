using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QianziNews.Data
{
    public class NewsImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int NewsId { get; set; }

        public News News { get; set; }

        
        public string MimeType { get; set; }
    }
}
