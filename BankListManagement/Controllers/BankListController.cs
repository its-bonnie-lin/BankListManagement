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
        public ActionResult QueryBankListResult(int BankCode, string Bank)
        {
            var list = _bankListCommands.QueryBankListResult(BankCode,Bank);
            
            return View(list);
        }
    }
}