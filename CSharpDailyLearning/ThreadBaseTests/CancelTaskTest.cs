using ThreadBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ThreadBaseTests
{
    [TestFixture]
    public class CancelTaskTest
    {
        /// <summary>
        /// Task.Factory.StartNew() 简写版 Task.Run()
        /// </summary>
        [Test]
        public void TaskFactoryNewRunTest()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task.Factory.StartNew()");
            });

            Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task.Run()");
            });

            // 不推荐这种写法
            var task = new Task(() =>
            {
                Thread.Sleep(1100);
                Console.WriteLine("new task Start()");
            });
            task.Start();
            task.Wait();
        }

        /// <summary>
        /// 消除
        /// </summary>
        [Test]
        public void CancellationToken()
        {
            
        }
    }
}
