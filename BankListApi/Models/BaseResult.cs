using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankListApi.Models
{
    public class BaseResult
    {

        /// <summary>
        /// 結果代碼
        /// </summary>
        public virtual int RtnCode { get; set; }

        /// <summary>
        /// 結果訊息
        /// </summary>
        public virtual string RtnMsg { get; set; }
    }
}