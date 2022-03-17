using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankListApi.Models;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net.Mail;

namespace BankListApi.Repositories
{
    public class BankListRepository
    {
        string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data", "banklist.xml");
        public List<BankBase> ReadBankList()
        {
            List<BankBase> bankLists = new List<BankBase>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList NodeLists = xmlDoc.SelectNodes("note/banklist");
            foreach (XmlNode xnFileCheck in NodeLists)
            {
                BankBase banklist = new BankBase();
                banklist.id = xnFileCheck.SelectSingleNode("id").InnerText;
                banklist.BankCode = xnFileCheck.SelectSingleNode("bankcode").InnerText;
                banklist.Bank = xnFileCheck.SelectSingleNode("bank").InnerText;
                bankLists.Add(banklist);
            }
            return bankLists;
        }
        #region 查詢
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
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
        public BaseResult AddBankList(AddBankList addBankList)
        {
            XDocument xmlDoc = XDocument.Load(filepath);
            int maxid = xmlDoc.Descendants("id").Max(x => (int)x);
            xmlDoc.Element("note").Add(new XElement("banklist",
                new XElement("id", maxid + 1),
                new XElement("bankcode", addBankList.BankCode),
                new XElement("bank", addBankList.Bank)));
            xmlDoc.Save(filepath);

            return new BaseResult()
            {
                RtnCode = 1,
                RtnMsg = "成功"
            };
        }
        #endregion

        public void SendMail(AddBankList addBankList)
        {
            
            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("bonnie@gmail.com", "Bonnie");
            mail.To.Add("cccooowww0203@gmail.com");
            mail.Priority = MailPriority.Normal;
            mail.Subject = "Bank List 新增資料";
            //內容
            mail.Body =
            "<h2>以下為新增資料</h2>" + "<table border=1; border-collapse:collapse; style=width:500px;text-align:center;><tbody><tr><td> 銀行代碼: </td><td> {BankCode} </td></tr><tr><td> 金融機構名稱: </td><td> {Bank} </td></tr></tbody></table>";
            mail.Body = mail.Body.Replace("{BankCode}", addBankList.BankCode);
            mail.Body = mail.Body.Replace("{Bank}", addBankList.Bank);
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient MySmtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            MySmtp.Credentials = new System.Net.NetworkCredential("bonbonnieuuu@gmail.com", "gmwgzdphkaasyzwp");
            MySmtp.EnableSsl = true;
            MySmtp.Send(mail);
            MySmtp = null;
            mail.Dispose();
        }
           
        

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UpdateBankList LoadID(string id)
        {
            var LoadResult = new UpdateBankList();
            XDocument xmlDoc = XDocument.Load(filepath);
            var querybankcode  = (from a in xmlDoc.Descendants("banklist")
                                 where (string)a.Element("id") == id
                                 select (string)a.Element("bankcode")).FirstOrDefault();

            var querybank = (from a in xmlDoc.Descendants("banklist")
                             where (string)a.Element("id") == id
                             select (string)a.Element("bank")).FirstOrDefault();

            LoadResult.id = id;
            LoadResult.BankCode = querybankcode;
            LoadResult.Bank = querybank;
            return LoadResult;
        }
        public BaseResult UpdateBankList(UpdateBankList updateBankList)
        {
            XDocument xmlDoc = XDocument.Load(filepath);
            
            var updatequery = from a in xmlDoc.Descendants("banklist")
                               where a.Element("id").Value == (updateBankList.id).ToString()
                               select a;
            foreach(var query in updatequery)
            {
                query.Element("bankcode").SetValue(updateBankList.BankCode);
                query.Element("bank").SetValue(updateBankList.Bank);
            }
            xmlDoc.Save(filepath);
            return new BaseResult()
            {
                RtnCode = 1,
                RtnMsg = "成功"
            };

        }
        #endregion

        #region 刪除
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public BaseResult DeleteBankList(string id)
        {
            XDocument xmlDoc = XDocument.Load(filepath);
            var deletequery = xmlDoc.Descendants("banklist").Where(x => x.Element("id").Value == id);
            deletequery.Remove();
            xmlDoc.Save(filepath);
            return new BaseResult()
            {
                RtnCode = 1,
                RtnMsg = "成功"
            };
        }
        #endregion
    }
}