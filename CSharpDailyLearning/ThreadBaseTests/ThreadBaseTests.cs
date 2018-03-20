using ThreadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ThreadBase.Tests
{
    [TestFixture]
    public class ThreadBaseTests
    {
        public const int Repetitions = 1000;
        [Test]
        public void RunTest()
        {
            // 线程委托
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
        private void DoWork()
        {
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("+");
            }
        }
    }
}