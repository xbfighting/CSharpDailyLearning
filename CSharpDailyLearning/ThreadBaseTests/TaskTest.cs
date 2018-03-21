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
        /// <summary>
        /// TASK
        /// </summary>
        [Test]
        public void RunTest()
        {
            const int repetitions = 1000;
            // Task.Factory.StartNew() 简写版 Task.Run()
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
        /// 轮询一个TASK<T>
        /// </summary>
        [Test]
        public void RunTest01()
        {
            Task<string> task = Task.Run<string>(() => PiCalculator.Calculate(100));
            foreach (var busySymbols in Utility.BusySymbols())
            {
                if (task.IsCompleted)
                {
                    Console.Write($"IsCompleted:{task.IsCompleted}");
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
            }, TaskContinuationOptions.OnlyOnFaulted);

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

        #region 异步线程 异常处理

        /// <summary>
        /// AggregateException 可以捕获多个异常
        /// </summary>
        [Test]
        public void ExcepetionHandleTest01()
        {
            Task task = Task.Run(() =>
            {
                throw new InvalidOperationException();
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                ex.Handle(eachException =>
                {
                    Console.WriteLine($"Error:{ex.Message}");
                    return true;
                });
            }
        }

        /// <summary>
        /// 使用ContinuWith来观察未处理的异常
        /// <remarks>无法捕捉</remarks>
        /// </summary>
        [Test]
        public void Excepetion_ContinueWithTest()
        {
            bool parentTaskFaulted = false;
            Task task = new Task(() =>
            {
                throw new InvalidOperationException();
            });

            Task continuationTask = task.ContinueWith((antecedentTask) =>
            {
                parentTaskFaulted = antecedentTask.IsFaulted;
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.Start();

            // 无法捕捉异常
            continuationTask.Wait();
            Trace.Assert(parentTaskFaulted);

            if (!task.IsFaulted)
            {
                task.Wait();
            }
            else
            {
                task.Exception.Handle(eachException =>
                {
                    Console.WriteLine($"ERROR:{eachException.Message}");
                    return true;
                });
            }
        }

        public static Stopwatch clock = new Stopwatch();

        /// <summary>
        /// 登记未处理的异常
        /// </summary>
        [Test]
        public void RegisterUnhandledException()
        {
            try
            {
                clock.Start();

                // 为未处理的异常注册一个回调获取提醒
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    Message("Event handler starting");
                    Delay(4000); // handle exception
                };

                Thread thread = new Thread(() =>
                {
                    Message("Throw exception");
                    throw new Exception();
                });

                thread.Start();
                Delay(2000);
            }
            finally
            {
                Message("Finally block running.");
            }
        }

        private static void Delay(int i)
        {
            Message($"Sleeping for {i} ms");
            Thread.Sleep(i);
            Message($"Awake");
        }

        private static void Message(string text)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : {clock.ElapsedMilliseconds}:{text}");
        }

        #endregion
    }

    #region 边角料
    public class Utility
    {
        public static IEnumerable<char> BusySymbols()
        {
            string busySymbols = @"QWERTYUIO";

            int next = 0;
            while (true)
            {
                yield return busySymbols[next];
                next = (next + 1)%busySymbols.Length;
                yield return '1';
            }
        }
    }

    public class PiCalculator
    {
        public static string Calculate(int digits = 100)
        {
            //Thread.Sleep(100);
            return digits.ToString();
        }
    }
    #endregion
}
