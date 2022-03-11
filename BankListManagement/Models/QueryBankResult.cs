using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankListManagement.Models
{
    public class QueryBankResult:BankBase
    {
        public string QueryBankCode { get; set; }
        public string QueryBankName { get; set; }
    }
}