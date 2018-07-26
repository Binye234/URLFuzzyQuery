using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLVariant
{
    /// <summary>
    /// URL变体域名生成类
    /// </summary>
    public class URLVariantClass
    {
        /// <summary>
        /// 域名头集合
        /// </summary>
        private string[] head;
        /// <summary>
        /// 域名尾集合
        /// </summary>
        private string[] footer;
        /// <summary>
        /// 原始变体字符串集合
        /// </summary>
        private List<string> VariantStringList;
        /// <summary>
        /// 替代字符集合
        /// </summary>
        private const string StringGather = "qwertyuiopasdfghjklzxcvbnm1234567890";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="head">域名头集合</param>
        /// <param name="footer">域名尾集合</param>
        public URLVariantClass(string[] head,string[] footer)
        {
            VariantStringList = new List<string>();
            this.head = head;
            this.footer = footer;
        }
        /// <summary>
        /// 原始变体字符串生成
        /// </summary>
        /// <param name="URLstring">原始域名</param>
        private void VariantStringCreate(string URLstring)
        {
            VariantStringList.Clear();
            for (int i = 0; i < URLstring.Length; i++)
            {
                for (int j = 0; j < StringGather.Length; j++)
                {
                    VariantStringList.Add(URLstring.Replace(URLstring[i], StringGather[j]));
                }
            }
        }
        /// <summary>
        /// 完整域名生成
        /// </summary>
        /// <param name="URLstring">URL字符串</param>
        /// <returns></returns>
        public List<string> URLstringCreate(string URLstring)
        {
            VariantStringCreate(URLstring);
            List<string> result = new List<string>();
            //原始字符串加头尾
            for(int i = 0; i < head.Length; i++)
            {
                for(int j = 0; j < footer.Length; j++)
                {
                    foreach(var item in VariantStringList)
                    {
                        result.Add(head[i] + item + footer[j]);
                    }
                }
            }
            return result;
        }
    }
}
