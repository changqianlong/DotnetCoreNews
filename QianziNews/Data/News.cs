using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QianziNews.Data
{
    public class News
    {
        //[Display(Name ="编号")]
        public int Id { get; set; }

        [Required(ErrorMessage ="标题不能为空!"),Display(Name ="标题")]     
        public string Title { get; set; }
        
        [Required(ErrorMessage ="新闻类别不能为空!"),Display(Name ="类别")]
        public string Category { get; set; }

        [Required(ErrorMessage ="内容不能为空"),MinLength(100,ErrorMessage ="内容最少为100字!"),Display(Name ="内容")]
        public string Content { get; set; }
        
        [Required(ErrorMessage ="提交时间不能为空!")]
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
        
        [Display(Name ="作者")]
        public string Author { get; set; } = "匿名";

        public string Source { get; set; }


        public List<NewsImage> Images { get; set; }

        public List<Comment> Comments { get; set; }

        
        public NewsDetail Detail { get; set; }

        public void CopyFrom(News item)
        {
            this.Title = item.Title;
            this.Content = item.Content;
            this.Category = item.Category;
            this.PostTime = item.PostTime;
            this.Author = item.Author;
            this.Source = item.Source;
            this.Images = item.Images;
        }
    }
}
