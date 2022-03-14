using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankListManagement.Models;
using System.Xml;
using System.IO;
using System.Xml.Linq;

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
                banklist.BankCode = xnFileCheck.SelectSingleNode("bankcode").InnerText;
                banklist.Bank = xnFileCheck.SelectSingleNode("bank").InnerText;
                bankLists.Add(banklist);
            }
            return bankLists;
        }

        /// <summary>
        /// 查詢
        /// </summary>
       
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            var QueryResult = new QueryBankResult();
            string query = "";
            XDocument xmlDoc = XDocument.Load(filepath);
            if (string.IsNullOrEmpty(SearchBank))
            {
                query = (from a in xmlDoc.Descendants("banklist")
                         where (string)a.Element("bankcode") == SearchBankCode
                         select (string)a.Element("bank")).FirstOrDefault();
                QueryResult.Bank = query;
                QueryResult.BankCode = SearchBankCode;
            }
            else if(string.IsNullOrEmpty(SearchBankCode))
            {
                query = (from a in xmlDoc.Descendants("banklist")
                         where (string)a.Element("bank") == SearchBank
                         select (string)a.Element("bankcode")).FirstOrDefault();
                QueryResult.Bank = SearchBank;
                QueryResult.BankCode = query;
            }
            return QueryResult;
        }

       public void AddBankList(AddBankList addBankList)
        {
            XDocument xmlDoc = XDocument.Load(filepath);
            xmlDoc.Element("note").Add(new XElement("banklist",
                new XElement("bankcode", addBankList.BankCode),
                new XElement("bank", addBankList.Bank)));
            xmlDoc.Save(filepath);
        }
    }
}