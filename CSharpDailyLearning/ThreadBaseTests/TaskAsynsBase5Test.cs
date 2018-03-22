using ThreadBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ThreadBaseTests
{
    [TestFixture]
    public class TaskAsynsBase5Test
    {
        [Test]
        public void HighDelay()
        {
            string url = "http://www.google.com";
            Console.WriteLine(url);
            Task task = WriteWebRequestSizeAsync(url);

            try
            {
                while (!task.Wait(100))
                {
                    Console.Write(".");
                }
            }
            catch (AggregateException ex)
            {
                ex = ex.Flatten();
                try
                {
                    ex.Handle(innerEx =>
                    {
                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                        return true;
                    });
                }
                catch (Exception exx)
                {
                    
                    throw exx;
                }
            }
        }

        /// <summary>
        /// WriteWebRequestSizeAsync
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Task WriteWebRequestSizeAsync(string url)
        {
            StreamReader reader = null;
            WebRequest webRequest = WebRequest.Create(url);

            Task task = webRequest.GetResponseAsync().ContinueWith(antecedent =>
            {
                WebResponse response = antecedent.Result;
                reader = new StreamReader(response.GetResponseStream());

                return reader.ReadToEndAsync();
            })
            .Unwrap()
            .ContinueWith(antecedent =>
            {
                if (reader!=null)
                {
                    reader.Dispose();
                }

                string text = antecedent.Result;
                Console.WriteLine(FormatBytes(text.Length));
            });

            return task;
        }

        /// <summary>
        /// FormatBytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string FormatBytes(long bytes)
        {
            string[] magnitudes = {"GB", "MB", "KB", "Bytes"};
            long max = (long) Math.Pow(1024, magnitudes.Length);

            return
                string.Format("{1:##.##} {0}",
                    magnitudes.FirstOrDefault(magnitude => bytes > (max /= 1024)) ?? "0 Bytes",
                    (decimal) bytes/(decimal) max).Trim();
        }
    }
}
