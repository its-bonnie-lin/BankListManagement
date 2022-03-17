using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankListApi.Controllers
{
    using Commands;
    using Repositories;
    using Services;
    using Models;
    public class BankListController : Controller
    {
        // GET: BankList
        private readonly BankListCommand _bankListCommands;
        private readonly BankListService _bankListServices;
        // https://localhost:44392/BankList/BankListIndex

        public BankListController(BankListCommand bankListCommands, BankListService bankListServices)
        {
            _bankListCommands = bankListCommands;
            _bankListServices = bankListServices;
        }

        public JsonResult BankListIndex()
        {
            var list = _bankListCommands.ReadBankList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="SearchBankCode"></param>
        /// <param name="SearchBank"></param>
        /// <returns></returns>
        //[HttpPost]
        public JsonResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            
            var list = _bankListCommands.QueryBankResult(SearchBankCode, SearchBank);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
        /// <returns></returns>
        
        public JsonResult AddBankList(AddBankList addBankList)
        {
            var result = _bankListCommands.AddBankList(addBankList);

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public ActionResult EditList(string id)
        {
            var result = _bankListCommands.LoadID(id);
            return Json(result, JsonRequestBehavior.AllowGet);
            //UpdateBankList _updateBankList =  _bankListCommands.LoadID(id);
            // return View(_updateBankList);
        }
        [HttpPost]
        public ActionResult EditBankList(UpdateBankList updateBankList)
        {
            var result = _bankListCommands.UpdateBankList(updateBankList);
            return Json(result, JsonRequestBehavior.AllowGet);
            //_bankListCommands.UpdateBankList(updateBankList);
            //return RedirectToAction("BankListIndex");
        }

        public ActionResult DeleteList(string id)
        {
            //_bankListCommands.DeleteBankList(id);
            //return RedirectToAction("BankListIndex");
            var result = _bankListCommands.DeleteBankList(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}