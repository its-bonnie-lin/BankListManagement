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
        //[HttpPost]
        public JsonResult AddBankList(AddBankList addBankList)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View("AddList", addBankList);
            //}
            var result = _bankListCommands.AddBankList(addBankList);

            return Json(result, JsonRequestBehavior.AllowGet);

            //return RedirectToAction("BankListIndex");
        }

        //public ActionResult AddList()
        //{
        //    return View();
        //}

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditList(string id)
        {
           UpdateBankList _updateBankList =  _bankListCommands.LoadID(id);
            return View(_updateBankList);
        }
        [HttpPost]
        public ActionResult EditList(UpdateBankList updateBankList)
        {
            if (!ModelState.IsValid)
            {
                return View("EditList", updateBankList);
            }
            _bankListCommands.UpdateBankList(updateBankList);
            return RedirectToAction("BankListIndex");
        }

        public ActionResult DeleteList(string id)
        {
            _bankListCommands.DeleteBankList(id);
            return RedirectToAction("BankListIndex");
        }
    }
}