using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBase
{
    /// <summary>
    /// 线程基础
    /// </summary>
    public class ThreadBase
    {
        public const int Repetitions = 1000;

        public void Run()
        {
            ThreadStart threadStart = DoWork;
            Thread thread = new Thread(threadStart);
            thread.Start();

            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("-");
            }

            thread.Join();
        }

        /// <summary>
        /// DoWork
        /// </summary>
        public void DoWork()
        {
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("+");
            }
        }
    }
}
