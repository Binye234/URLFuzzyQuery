using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace URLVariant
{
    /// <summary>
    /// URL工具类
    /// </summary>
    public static class URLtool
    {
        /// <summary>
        /// 判别URL是否符合要求
        /// </summary>
        /// <param name="input">输入URL字符串</param>
        /// <returns></returns>
        public static bool IsURLString(string UrlString)
        {
            string regex = @"^(http://|https//)?[a-zA-Z0-9]+(.net|.com|.cn)?$";
            return Regex.IsMatch(UrlString, regex);
        }
        /// <summary>
        /// 取URL内字符串，去掉头尾
        /// </summary>
        /// <param name="UrlString">URL字符串</param>
        /// <returns></returns>
        public static string GetURLInnerString(string UrlString)
        {
            int first = UrlString.IndexOf(".");
            if (first >= 0)
            {
                UrlString = UrlString.Remove(0, first + 1);
            }
            int last = UrlString.LastIndexOf(".");
            if (last >= 0)
            {
                UrlString = UrlString.Substring(0, last);
            }
            return UrlString;
        }
    }
}
