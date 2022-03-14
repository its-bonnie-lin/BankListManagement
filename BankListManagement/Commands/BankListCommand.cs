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
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            var result = _bankListService.QueryBankResult(SearchBankCode, SearchBank);
            return result;
        }

        public void AddBankList(AddBankList addBankList)
        {
            _bankListService.AddBankList(addBankList);
        }
    }
}