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
        /// <param name="SearchBankCode"></param>
        /// <param name="SearchBank"></param>
        /// <returns></returns>
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            var result = _bankListService.QueryBankResult(SearchBankCode, SearchBank);
            return result;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
        public void AddBankList(AddBankList addBankList)
        {
            _bankListService.AddBankList(addBankList);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateBankList"></param>

        public UpdateBankList LoadID(string id)
        {
            return _bankListService.LoadID(id);
        }
        public void UpdateBankList(UpdateBankList updateBankList)
        {
            _bankListService.UpdateBankList(updateBankList);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBankList(string id)
        {
            _bankListService.DeleteBankList(id);
        }
    }
}