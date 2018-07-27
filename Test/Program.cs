using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLVariant;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            URLVariantClass uRLVariantClass = new URLVariantClass(new string[] { @"https://www.", @"http://www." }, new string[] { ".net", ".com", ".cn" });
            var list = uRLVariantClass.URLstringCreate("hao123");
            URLClient uRLClient = new URLClient(a => Console.WriteLine(a));
            uRLClient.UrlListQuery(list);


            Console.ReadKey();
        }
    }
}
