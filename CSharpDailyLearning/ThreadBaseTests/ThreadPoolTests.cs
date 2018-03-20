using ThreadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ThreadBaseTests
{
    [TestFixture]
    public class ThreadPoolTests
    {
        public const int Repetitions = 1000;

        [Test]
        public void RunTest()
        {
            ThreadPool.QueueUserWorkItem(DoWork, "+");
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("-");
            }

            Thread.Sleep(1000);
        }

        /// <summary>
        /// DoWork
        /// </summary>
        private void DoWork(object state)
        {
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write(state);
            }
        }

    }
}
