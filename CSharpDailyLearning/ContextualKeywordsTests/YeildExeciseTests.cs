//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContextualKeywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContextualKeywords.Tests
{
    [TestFixture]
    public class YeildExeciseTests
    {

        [Test]
        public void YeildTest01()
        {
            // given
            foreach (var item in Integers())
            {
                Console.WriteLine(item);
            }
        }

        private IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 12;
            yield return 13;
            yield return 14;
            yield return 15;
            yield return 16;
            yield return 17;
            yield return 188;
        }


        [Test]
        public void YeildTest02()
        {
            // given
            foreach (var item in IntegerGenerator(50*50))
            {
                Console.WriteLine(item);
            }
        }

        private IEnumerable<int> IntegerGenerator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }
    }
}