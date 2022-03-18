using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankListManagement.Models;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;
using System.Net;

namespace BankListManagement.Repositories
{
    public class BankListRepository
    {
        string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data", "banklist.xml");
        public List<BankBase> ReadBankList()
        {
            string URL = "https://localhost:44392/BankList/BankListIndex";
            return  PostToApi<List<BankBase>>(URL, null);
        }
       
        /// <summary>
        /// 查詢
        /// </summary>
        public QueryBankResult QueryBankResult(string SearchBankCode, string SearchBank)
        {
            string URL = "https://localhost:44392/BankList/QueryBankResult";
            return PostToApi<QueryBankResult>(URL, new {
                SearchBankCode,
                SearchBank
            });
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addBankList"></param>
       public BaseResult AddBankList(AddBankList addBankList)
        {
            string URL = "https://localhost:44392/BankList/AddBankList";
            return PostToApi<BaseResult>(URL, addBankList);
        }
       
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UpdateBankList LoadID(string id)
        {
            string URL = "https://localhost:44392/BankList/EditList";
            return PostToApi<UpdateBankList>(URL, new { 
                id = id
            });
        }
        public BaseResult UpdateBankList(UpdateBankList updateBankList)
        {
            string URL = "https://localhost:44392/BankList/EditBankList";
           return PostToApi<BaseResult>(URL, updateBankList);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public BaseResult DeleteBankList(string id)
        {
            string URL = "https://localhost:44392/BankList/DeleteList";
           return PostToApi<BaseResult>(URL, new
           {
               id = id
           });
        }

        /// <summary>
        /// Post方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private T PostToApi<T>(string url, object obj) 
        {

            string json = JsonConvert.SerializeObject(obj);
            string postResul = DoRequestWithJson(url, json);
            var resModel = JsonConvert.DeserializeObject<T>(postResul);

            return resModel;
        }

        #region DoRequestWithJson
        /// <summary>
        ///  NetworkHelper
        /// </summary>
        private int _defaultTimeout = 15;
        public int DefaultTimeout
        {
            get
            {
                return _defaultTimeout;
            }
            set
            {
                _defaultTimeout = value;
            }
        }
        public string DoRequest(string url, string data, string contentType,
                        int timeoutSeconds, CookieContainer cookieContainer, IDictionary<string, string> headers)
        {
            //如果是https請求
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                // 忽略憑證
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((s, cert, chain, errors) => true);
            }

            //### 建立HttpWebRequest物件
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.ProtocolVersion = HttpVersion.Version10;

            //### 指定送出去的方式為POST
            httpWebRequest.Method = "POST";
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            httpWebRequest.Accept = "text/html";
            httpWebRequest.Referer = "";

            //### 設定content type, it is required, otherwise it will not work.
            httpWebRequest.ContentType = contentType;

            //設定Timeout時間(單位毫秒)
            httpWebRequest.Timeout = ((timeoutSeconds > 10000000) ? timeoutSeconds : DefaultTimeout) * 1000;

            string receiveData = null;

            //### 取得request stream 並且寫入post data
            using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //### 設定要送出的參數; separated by "&"
                sw.Write(data ?? string.Empty);
                sw.Flush();
                sw.Close();
            }

            //### 取得server的reponse結果
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
            {
                receiveData = sr.ReadToEnd();
                sr.Close();
            }

            httpWebResponse.Close();

            return receiveData;
        }
        public string DoRequestWithJson(string url, string json)
        {
            return DoRequest(url, json, "application/json", 0, null, null);
        }
        #endregion
    }
}