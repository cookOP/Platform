using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GGPlatform.Common.HttpHelper
{
    /// <summary>
    /// 模拟请求类
    /// </summary>
    /// <author>旷丽文</author>
    public class RequestUrl
    {
        private bool _RunSuccess;
        /// <summary>
        /// 获取是否执行成功
        /// </summary>
        public bool RunSuccess
        {
            get { return _RunSuccess; }
        }

        private string _Data;
        /// <summary>
        /// 获取响应成功返回的值，执行失败返回string.Empty
        /// </summary>
        public string Data
        {
            get { return _Data; }
        }

        private string _ErrorMsg;
        /// <summary>
        /// 获取请求失败返回的消息
        /// </summary>
        public string ErrorMsg
        {
            get { return _ErrorMsg; }
        }

        /// <summary>
        /// 设置或获取请求的地址属性
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 设置或获取请求的参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 获取或设置参数的编码格式，默认为UTF8
        /// </summary>
        public Encoding ParamEncoding { get; set; }

        /// <summary>
        /// 获取或设置响应内容的编码格式，默认为UTF8
        /// </summary>
        public Encoding DataEncoding { get; set; }

        /// <summary>
        /// 获取或设置Content-type HTTP标头的值。默认为application/x-www-form-urlencoded
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 获取或设置要在 HTTP 请求中独立于请求 URI 使用的 Host 标头值。默认不设置，此参数不是必要不要设置，否则请求失败
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取或设置 Connection HTTP 标头的值。默认不设置，此参数不是必要不要设置，否则请求失败
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// 获取或设置 User-agentHTTP 标头的值。默认不设置（此属性为浏览器信息和系统信息，一般不要设置）
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 请求头信息
        /// </summary>
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 请求方式
        /// </summary>
        public string Method { get; set; } = "POST";

        /// <summary>
        /// 构造函数，为必要设置的属性赋值
        /// </summary>
        /// <param name="url">请求地址</param>
        public RequestUrl(string url)
        {
            Url = url;
            ParamEncoding = Encoding.UTF8;
            DataEncoding = Encoding.UTF8;
            ContentType = "application/x-www-form-urlencoded";
        }

        /// <summary>
        /// Get请求
        /// </summary>
        public void GetUrl()
        {
            string parm = string.Empty;
            if (!string.IsNullOrWhiteSpace(Parameter)) parm = "?" + Parameter;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + parm);
                request.Method = Method;
                request.ContentType = ContentType;
                foreach (var item in Header)
                {
                    request.Headers.Add(item.Key, item.Value);
                }

                if (!string.IsNullOrWhiteSpace(UserAgent)) request.UserAgent = UserAgent;
                if (!string.IsNullOrWhiteSpace(Host)) request.Host = Host;
                if (!string.IsNullOrWhiteSpace(Connection)) request.Connection = Connection;
                using (WebResponse response = request.GetResponse())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), DataEncoding);
                    _Data = sr.ReadToEnd();
                    _RunSuccess = true;
                    _ErrorMsg = string.Empty;
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                _ErrorMsg = ex.Message;
                _RunSuccess = false;
                _Data = string.Empty;
            }
        }

        /// <summary>
        /// Post请求
        /// </summary>
        public void PostUrl()
        {
            byte[] bs = null;
            if (!string.IsNullOrWhiteSpace(Parameter))
            {
                bs = ParamEncoding.GetBytes(Parameter);
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = Method;
                request.ContentType = ContentType;
                foreach (var item in Header)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
                if (!string.IsNullOrWhiteSpace(UserAgent)) request.UserAgent = UserAgent;
                if (!string.IsNullOrWhiteSpace(Host)) request.Host = Host;
                if (!string.IsNullOrWhiteSpace(Connection)) request.Connection = Connection;
                if (bs != null)
                {
                    request.ContentLength = bs.Length;
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(bs, 0, bs.Length);
                    }
                }
                using (WebResponse response = request.GetResponse())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), DataEncoding);
                    _Data = sr.ReadToEnd();
                    _RunSuccess = true;
                    _ErrorMsg = string.Empty;
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                _ErrorMsg = ex.Message;
                _RunSuccess = false;
                _Data = string.Empty;
            }
        }
    }
}
