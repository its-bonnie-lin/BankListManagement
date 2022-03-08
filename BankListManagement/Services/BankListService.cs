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
        /// <param name="BankCode">銀行代碼</param>
        /// <param name="Bank">銀行</param>
        /// <returns></returns>
        public List<BankBase> QueryBankListResult(int BankCode, string Bank)
        {
            return _bankListRepository.QueryBankListResult(BankCode, Bank);
        }
    }
}