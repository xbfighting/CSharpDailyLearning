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

        #region 这里的例子实现的不是很棒
        /// <summary>
        /// 取消线程
        /// </summary>
        [Test]
        public void CancellationToken()
        {
            string stars = "*".PadRight(Console.WindowWidth, '*');
            Console.WriteLine("Push ENTER to exit.");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task task = Task.Run(()=> WritePi(cancellationTokenSource.Token), cancellationTokenSource.Token);
            Thread.Sleep(10); // 模拟用户按下了 Enter
            cancellationTokenSource.Cancel();
            Console.WriteLine(stars);
            task.Wait();
            Console.WriteLine();
        }

        /// <summary>
        /// PI
        /// </summary>
        private void WritePi(CancellationToken cancellationToken)
        {
            const int batchSize = 1;
            string piSection = String.Empty;
            int i = 0;

            while (!cancellationToken.IsCancellationRequested || i == int.MaxValue)
            {
                piSection = PiCalculator.Calculate(batchSize, (i++)*batchSize);
                Console.Write(piSection);

            }
        }
        #endregion


    }
}
