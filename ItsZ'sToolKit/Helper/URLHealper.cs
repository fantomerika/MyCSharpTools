using Framework.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ItsZ_sToolKit.Helper
{
    public static class URLHealper
    {
        /// <summary>
        /// 获取当前 http://www.xxx.com 格式的字符串
        /// </summary>
        /// <returns></returns>
        public static string getRequestApplicationUrl()
        {
            HttpContext currentHttp = HttpContext.Current;
            string abc = currentHttp.Server.MapPath(currentHttp.Request.ApplicationPath);
            Uri url = currentHttp.Request.Url;
            string appPaht = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
            return string.Format("{0}://{1}{2}", url.Scheme, url.Authority, appPaht);
        }

        public static string constructFullUrl(string virtualUrl)
        {
            if (string.IsNullOrEmpty(virtualUrl) || virtualUrl == "~/")
            {
                return virtualUrl;
            }
            return getRequestApplicationUrl() + virtualUrl.Substring(1);
        }
        /// <summary>
        /// 获取客户端Ip地址
        /// </summary>
        /// <returns></returns>
        public static string getClientHostAddress()
        {
            string ReturnData;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            {
                ReturnData = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ReturnData = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (ReturnData.IsNullOrWhiteSpace())
            {
                ReturnData = HttpContext.Current.Request.UserHostAddress;
            }
            return ReturnData;
        }
    }
}
