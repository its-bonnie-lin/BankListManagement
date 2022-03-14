using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

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

        public ActionResult BankListIndex()
        {
            var list = _bankListCommands.ReadBankList();
            return View(list);
        }

        [HttpPost]
        public ActionResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            
            var list = _bankListCommands.QueryBankResult(SearchBankCode, SearchBank);
            
            return View(list);
        }

        [HttpPost]
        public ActionResult AddBankList(AddBankList addBankList)
        {
            if(!ModelState.IsValid)
            {
                return View("AddList");
            }
            _bankListCommands.AddBankList(addBankList);
            return RedirectToAction("BankListIndex");
        }
        public ActionResult AddList()
        {
            return View();
        }
    }
}