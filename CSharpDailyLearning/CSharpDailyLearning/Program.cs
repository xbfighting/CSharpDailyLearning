using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Delegate;

namespace CSharpDailyLearning
{
    class Program
    {
        private static void Main(string[] args)
        {
            //TEST t = new TEST(2);
            //Console.WriteLine(t.getT());
            //TEST t1 = new TEST(3);
            //Console.WriteLine(t.getT());
            //Console.WriteLine(t1.getT());

            //st s;
            //s = new st(1, false);
            //Console.WriteLine(s.i);

            //var result = DelegateActionFun.Compare(2, 1, DelegateActionFun.Rule1);
            //Console.WriteLine("Int compare result:{0}", result);


            var e = new EventTest000();
            e.Test();
        }
    }

    public class TEST
    {
        private static int t = 1;

        public TEST(int myT)
        {
            t = myT;
        }

        public int getT()
        {
            return t;
        }
    }

    public struct st
    {
        public int i;
        private bool b;

        public st (int ii, bool bb)
        {
            this.i = ii;
            b = false;
        }
    }


    public class DelegateActionFun
    {
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static bool Compare<T>(T t1, T t2, Func<T, T, bool> ruleFunc)
        {
            return ruleFunc.Invoke(t1, t2);
        }

        public static bool Rule1(int t1, int t2)
        {
            return t1 - t2 > 0;
        }

        //public static void Main(string[] args)
        //{
        //    var result = Compare(1, 2, rule1);
        //    Console.WriteLine("Int compare result:{0}", result);
        //}
    }
}
