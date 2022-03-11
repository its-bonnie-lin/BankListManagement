using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankListManagement.Models
{
    public class BankBase
    {
        //[Required(ErrorMessage = "這是必填欄位")]
        //[RegularExpression(@"^\d{3}$", ErrorMessage = "格式錯誤")]
        public string BankCode { get; set; }
        public string Bank { get; set; }
    }
}