using ThreadBase;
using System;
using System.Collections.Generic;
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
        
        [Test]
        public void ContinueWithTest()
        {
            Console.WriteLine("Before");
            Task taskA = Task.Run(() =>
            {
                Console.WriteLine("Starting...");
            }).ContinueWith(anencedent => Console.WriteLine("Continuing A..."));

            Task taskB = taskA.ContinueWith(antecedent => Console.WriteLine("Continuing B..."));
            Task taskC = taskB.ContinueWith(antecedent => Console.WriteLine("Continuing C..."));

            Task.WaitAll(taskB, taskC);

            Console.WriteLine("Finished!");
        }
    }

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
}
