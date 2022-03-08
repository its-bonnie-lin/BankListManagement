using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankListManagement.Models;
using System.Xml;
using System.IO;

namespace BankListManagement.Repositories
{
    public class BankListRepository
    {

        string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data", "banklist.xml");
        public List<BankBase> ReadBankList()
        {
            List<BankBase> bankLists = new List<BankBase>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            //取得結點
            XmlNodeList NodeLists = xmlDoc.SelectNodes("note/banklist");
            
            foreach (XmlNode xnFileCheck in NodeLists)
            {
                    BankBase banklist = new BankBase();
                    banklist.BankCode = Convert.ToInt32(xnFileCheck.SelectSingleNode("bankcode").InnerText);
                    banklist.Bank = xnFileCheck.SelectSingleNode("bank").InnerText;
                    bankLists.Add(banklist);
            }
            return bankLists;
        }
        public virtual List<BankBase> QueryBankListResult(int BankCode, string Bank)
        {
            List<BankBase> bankLists = new List<BankBase>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList NodeLists = xmlDoc.SelectNodes("note/banklist");

            foreach (XmlNode xnFileCheck in NodeLists)
            {
                BankBase banklist = new BankBase();
                banklist.BankCode = Convert.ToInt32(xnFileCheck.SelectSingleNode("bankcode").InnerText);
                banklist.Bank = xnFileCheck.SelectSingleNode("bank").InnerText;
                bankLists.Add(banklist);
            }
            return bankLists;
        }
    }
}