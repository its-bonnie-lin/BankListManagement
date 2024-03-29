﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using PagedList;
using PagedList.Mvc;

namespace BankListManagement.Controllers
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

        public BankListController(BankListCommand bankListCommands, BankListService bankListServices)
        {
            _bankListCommands = bankListCommands;
            _bankListServices = bankListServices;
        }

        public ActionResult BankListIndex(int page = 1, int pageSize = 40)
        {
            var list = _bankListCommands.ReadBankList().ToList();
            var result = list.ToPagedList(page, pageSize);
            return View(result);
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="SearchBankCode"></param>
        /// <param name="SearchBank"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            var list = _bankListCommands.QueryBankResult(SearchBankCode, SearchBank);
            
            return View(list);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBankList(AddBankList addBankList)
        {
            if(!ModelState.IsValid)
            {
                return View("AddList", addBankList);
            }
            _bankListCommands.AddBankList(addBankList);
            return RedirectToAction("BankListIndex");
        }
        public ActionResult AddList()
        {
            return View();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditList(string id)
        {
           UpdateBankList _updateBankList =  _bankListCommands.LoadID(id);
            return View(_updateBankList);
        }
        [HttpPost]
        public ActionResult EditBankList(UpdateBankList updateBankList)
        {
            if (!ModelState.IsValid)
            {
                return View("EditList", updateBankList);
            }
            _bankListCommands.UpdateBankList(updateBankList);
            return RedirectToAction("BankListIndex");
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteList(string id)
        {
            _bankListCommands.DeleteBankList(id);
            return RedirectToAction("BankListIndex");
        }
    }
}