using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankListManagement.Models
{

    public class BaseResult
    {
        /// <summary>
        /// 結果代碼
        /// </summary>
        public int RtnCode { get; set; }

        /// <summary>
        /// 結果訊息
        /// </summary>
        public string RtnMsg { get; set; }
    }
}