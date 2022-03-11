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
        /// <param name="QueryBankCode"></param>
        /// <param name="QueryBankName"></param>
        /// <returns></returns>
        public QueryBankResult QueryBankResult(string QueryBankCode, string QueryBankName)
        {
            var QueryResult = new QueryBankResult();
            XDocument xmlDoc = XDocument.Load(filepath);
            if (string.IsNullOrWhiteSpace(QueryBankName) && !(string.IsNullOrWhiteSpace(QueryBankCode)))
            {
                QueryResult = (from a in xmlDoc.Descendants("banklist")
                               where (string)a.Element("bankcode") == QueryBankCode
                               select new QueryBankResult
                               {
                                   QueryBankName = (string)a.Element("bank"),
                                   QueryBankCode = (string)a.Element("bankcode")
                               }).FirstOrDefault();
                return QueryResult;
            }
            else if ( ( (string.IsNullOrWhiteSpace(QueryBankCode)) && !(string.IsNullOrWhiteSpace(QueryBankName))))
            {
                QueryResult = (from a in xmlDoc.Descendants("banklist")
                               where (string)a.Element("bank") == QueryBankName
                               select new QueryBankResult
                               {
                                   QueryBankName = (string)a.Element("bank"),
                                   QueryBankCode = (string)a.Element("bankcode")
                               }).FirstOrDefault() ;
                return QueryResult;
            }
            return QueryResult;
        }
    }
}