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
        /// <param name="BankCode"></param>
        /// <param name="Bank"></param>
        /// <returns></returns>
        public List<BankBase> QueryBankListResult(int BankCode, string Bank)
        {
            var result = _bankListService.QueryBankListResult(BankCode, Bank);
            return result;
        }
    }
}