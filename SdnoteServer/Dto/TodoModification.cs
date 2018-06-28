using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SdnoteServer.Dto
{
    public class TodoModification
    {
        [Display(Name = "事件名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "{0}的长度应在{2}—{1}之间")]
        public string TdName { get; set; }

        [Display(Name = "事件时间")]
        public DateTime TdTime { get; set; }
    }
}
