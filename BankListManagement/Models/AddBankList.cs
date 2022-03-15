using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankListManagement.Models
{
    public class AddBankList
    {
        public string id { get; set; }

        [Required(ErrorMessage = "這是必填欄位1")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "格式錯誤")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "這是必填欄位2")]
        public string Bank { get; set; }
    }
}