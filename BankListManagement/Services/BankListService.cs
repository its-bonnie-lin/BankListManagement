using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BankListManagement.Services
{
    using Repositories;
    using Models;
    public class BankListService
    {
        private BankListRepository _bankListRepository;
        public BankListService(BankListRepository bankListRepository)
        {
            _bankListRepository = bankListRepository;
        }
        public List<BankBase> ReadBankList()
        {
            return _bankListRepository.ReadBankList();
        }
        
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="QueryBankCode"></param>
        /// <param name="QueryBankName"></param>
        /// <returns></returns>
        public QueryBankResult QueryBankResult(string QueryBankCode, string QueryBankName)
        {
            return _bankListRepository.QueryBankResult(QueryBankCode, QueryBankName);

        }
    }
}