using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QianziNews.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please input Content!")]
        [StringLength(1000,MinimumLength =1,ErrorMessage ="Content Length is too short!")]
        public string Content { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required] 
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }

        public int Zan { get; set; } = 0;

        public News News { get; set; }

        public int NewsId { get; set; }

    }
}
