using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = " {0 最小 {2} 最大为{1} ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("NewPassword", ErrorMessage = "两次输入不一致.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
