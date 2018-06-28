using System;
using System.ComponentModel.DataAnnotations;

namespace SdnoteServer.Dto
{
    public class TodoCreation
    {
        [Display(Name="事件名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        //[MinLength(2,ErrorMessage = "{0}最小长度为{1}")]
        //[MaxLength(32,ErrorMessage = "{0}最大长度是{1}")]
        [StringLength(32, MinimumLength = 2,ErrorMessage = "{0}的长度应在{2}—{1}之间" )]
        public string TdName { get; set; }

        [Display(Name = "事件时间")]
        //[RegularExpression(@"\d{2,4}-\d{1,2}-\d{1,2}\s\d{1,2}:\d{1,2}:\d{1,2}", ErrorMessage = "格式错误")]
        //[DataType(DataType.Date ,ErrorMessage = "格式错误")]
        public DateTime TdTime { get; set; }
    }
}
