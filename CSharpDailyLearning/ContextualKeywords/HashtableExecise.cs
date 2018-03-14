using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualKeywords
{
    public class HashtableExecise
    {
        public int SimpleHash(string s, string[] arr)
        {
            int tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            var tempBound = cname.GetUpperBound(0);
            for (int i = 0; i <= tempBound; i++)
            {
                tot += (Int32) cname[i];
            }

            var arrBound = arr.GetUpperBound(0);
            var result = tot%arrBound;
            return result;
        }

        public void ShowDistrib(string[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                if (arr[i] != null)
                    Console.WriteLine(i + " " + arr[i]);
        }
    }
}
