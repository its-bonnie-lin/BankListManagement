using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankListManagement.Controllers
{
    using Commands;
    using Repositories;
    using Services;
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
        public ActionResult QueryBankResult(string QueryBankCode, string QueryBankName)
        {
            if (string.IsNullOrWhiteSpace(QueryBankCode) && string.IsNullOrWhiteSpace(QueryBankName))
            {
                return View(_bankListCommands.ReadBankList());
            }
            var list = _bankListCommands.QueryBankResult(QueryBankCode, QueryBankName);
            
            return View(list);
        }
    }
}