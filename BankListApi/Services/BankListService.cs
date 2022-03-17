using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BankListApi.Services
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
        /// <param name="SearchBankCode"></param>
        /// <param name="SearchBank"></param>
        /// <returns></returns>
        
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            
            return _bankListRepository.QueryBankResult(SearchBankCode, SearchBank);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
        public BaseResult AddBankList(AddBankList addBankList)
        {
           return _bankListRepository.AddBankList(addBankList);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateBankList"></param>
        public UpdateBankList LoadID(string id)
        {
            return _bankListRepository.LoadID(id);
        }
        public BaseResult UpdateBankList(UpdateBankList updateBankList)
        {
            return _bankListRepository.UpdateBankList(updateBankList);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public BaseResult DeleteBankList(string id)
        {
            return _bankListRepository.DeleteBankList(id);
        }
    }

}