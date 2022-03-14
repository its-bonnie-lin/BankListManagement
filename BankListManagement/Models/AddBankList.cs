using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankListManagement.Models
{
    public class AddBankList
    {
        
        public string BankCode { get; set; }

        [Required(ErrorMessage = "這是必填欄位")]
    
        
        public string Bank { get; set; }
    }
}