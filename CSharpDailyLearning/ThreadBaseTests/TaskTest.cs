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
    public class TaskTest
    {
        [Test]
        public void RunTest()
        {
            const int repetitions = 1000;

            var task = Task.Run(() =>
            {
                for (int i = 0; i < repetitions; i++)
                {
                    Console.Write("-");
                }
            });

            for (int i = 0; i < repetitions; i++)
            {
                Console.Write("+");
            }

            // Wait until the Task completes
            task.Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RunTest01()
        {
            Task<string> task = Task.Run<string>(() => PiCalculator.Calculate(100));
            foreach (var busySymbols in Utility.BusySymbols())
            {
                if (task.IsCompleted)
                {
                    Console.Write('\b');
                    break;
                }
                Console.Write(busySymbols);
            }
            Console.WriteLine();
            Console.WriteLine(task.Result);
            System.Diagnostics.Trace.Assert(task.IsCompleted);
        }

        /// <summary>
        /// ContinueWithTest
        /// </summary>
        [Test]
        public void ContinueWithTest()
        {
            Console.WriteLine("Before");
            Task taskA = Task.Run(() =>
            {
                Console.WriteLine("Starting...");
            }).ContinueWith(anencedent => Console.WriteLine("Continuing A..."));

            Task taskB = taskA.ContinueWith(antecedent => Console.WriteLine("Continuing B..."));
            Task taskC = taskA.ContinueWith(antecedent => Console.WriteLine("Continuing C..."));

            Task.WaitAll(taskB, taskC);

            Console.WriteLine("Finished!");

            /*
             * Before Starting... 
             * Continuing A... 
             * Continuing C... 
             * Continuing B... 
             * Finished!         
             * 
             * PS:B和C的顺序不一定是CB 
             */
        }

        /// <summary>
        /// ContinueWith 的一些可选属性
        /// </summary>
        [Test]
        public void ContinueWithTest02()
        {
            Task<string> task = Task.Run<string>(() => PiCalculator.Calculate(10));

            // 本程序中 faultedTask 和 canceledTask 不可能发生，所以不可以等待。
            Task faultedTask = task.ContinueWith((antecedentTask) =>
            {
                Trace.Assert(task.IsFaulted);
                Console.WriteLine("Task State:Faulted");
            },TaskContinuationOptions.OnlyOnFaulted);

            Task canceledTask = task.ContinueWith((antecedentTask) =>
            {
                Trace.Assert(task.IsCanceled);
                Console.WriteLine("Task State:Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Task completedTask = task.ContinueWith((antecedentTask) =>
            {
                Trace.Assert(task.IsCompleted);
                Console.WriteLine("Task State:Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
    }

    #region 边角料
    public class Utility
    {
        public static IEnumerable<char> BusySymbols()
        {
            string busySymbols = @"-\|/-\|/";

            int next = 0;
            while (true)
            {
                yield return busySymbols[next];
                next = (next + 1)%busySymbols.Length;
                yield return '\b';
            }
        }
    }

    public class PiCalculator
    {
        public static string Calculate(int digits = 100)
        {
            return digits.ToString();
        }
    }
    #endregion
}
