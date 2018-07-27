using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace URLVariant
{
    public class URLClient
    {
        /// <summary>
        /// 回掉方法
        /// </summary>
        private Action<string> backAction;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="action">回掉方法</param>
        public URLClient(Action<string> action)
        {
            backAction = action;
        }
        /// <summary>
        /// 域名验证方法
        /// </summary>
        /// <param name="UrlString">域名</param>
        /// <returns></returns>
        private async Task IsHasUrlAsync(string UrlString, Action action)
        {
            using (HttpClient hc = new HttpClient())
            {
                var result = await hc.GetAsync(UrlString);
                action();
                if (200 <= (int)result.StatusCode && (int)result.StatusCode < 400)
                {
                    //执行回掉方法
                    backAction(UrlString);
                }
            }
        }
        /// <summary>
        /// Url集合查询
        /// </summary>
        /// <param name="UrlList"></param>
        public void UrlListQuery(List<string> UrlList,Action action)
        {
            foreach(var item in UrlList)
            {
                
                IsHasUrlAsync(item,action);
            }
        }
    }
}
