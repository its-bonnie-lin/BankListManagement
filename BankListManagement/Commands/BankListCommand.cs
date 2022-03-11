using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankListManagement.Commands
{
    using Models;
    using Services;
    public class BankListCommand
    {
        private readonly BankListService _bankListService;
        public BankListCommand(BankListService bankListService)
        {
            _bankListService = bankListService;
        }
        public List<BankBase> ReadBankList()
        {
            var result = _bankListService.ReadBankList();
            return result;
        }
        
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="QueryBankCode"></param>
        /// <param name="QueryBankName"></param>
        /// <returns></returns>
        public QueryBankResult QueryBankResult(string QueryBankCode, string QueryBankName)
        {
            var result = _bankListService.QueryBankResult(QueryBankCode, QueryBankName);
            return result;
        }
    }
}