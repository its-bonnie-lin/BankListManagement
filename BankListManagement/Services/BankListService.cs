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
        
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            
            return _bankListRepository.QueryBankResult(SearchBankCode, SearchBank);
        }

        public void AddBankList(AddBankList addBankList)
        {
            _bankListRepository.AddBankList(addBankList);
        }
    }

}