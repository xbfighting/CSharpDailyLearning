using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class DelegateActionFun
    {
        public static bool Compare<T>(T t1, T t2, Func<T, T, bool> ruleFunc)
        {
            return ruleFunc.Invoke(t1, t2);
        }

        //Comparer<int> (int i1, int i2, )

        public static bool rule1(int t1, int t2)
        {
            return t1 - t2 > 0;
        }

        public static void Main(string[] args)
        {
            var result = Compare(1, 2, rule1);
            Console.WriteLine("Int compare result:{0}", result);
        }
    }

    public class EventTest
    {
        
    }
}
