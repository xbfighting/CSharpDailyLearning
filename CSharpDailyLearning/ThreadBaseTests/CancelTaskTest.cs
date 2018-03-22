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

        #region 不是打印Pi的每一位数但是模拟延迟打印随机数字
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
            Thread.Sleep(100); // 模拟用户按下了 Enter
            cancellationTokenSource.Cancel();
            Console.WriteLine();
            Console.WriteLine(stars);
            task.Wait();
            Console.WriteLine();

            /* OUT PUT
             * 
             * Push ENTER to exit.
             * 221456847
             * *********************************************
             * 2 // 这里也是一个随机数，因为cancellationTokenSource.Cancel(); 后，极有可能又做了一次迭代。
             */
        }

        /// <summary>
        /// PI
        /// </summary>
        private void WritePi(CancellationToken cancellationToken)
        {
            string piSection = String.Empty;
            int i = 0;

            while (!cancellationToken.IsCancellationRequested || i == int.MaxValue)
            {
                Thread.Sleep(10);
                i++;
                piSection = new Random().Next(i).ToString();
                Console.Write(piSection);
            }
        }
        #endregion
    }
}
