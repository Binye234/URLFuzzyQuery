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
            var a = URLtool.GetURLInnerString(@"https://www.hao123.com");
            string[] head = { @"http://www.", @"https://www." };
            string[] footer = { ".net", ".com", ".cn" };
            URLVariantClass uRLVariantClass = new URLVariantClass(head,footer);
            var list = uRLVariantClass.URLstringCreate(a);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(list.Count);



            Console.ReadKey();
        }
    }
}
