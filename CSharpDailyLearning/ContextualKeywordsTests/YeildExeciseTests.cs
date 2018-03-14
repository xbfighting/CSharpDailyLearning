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

        [Test]
        public void YeildTest03()
        {
            IEnumerable<YeildExecise.Vector> vectors = GetVectors();
            foreach (var item in vectors)
            {
                item.X = 4;
                item.Y = 4;
            }

            foreach (var item in vectors)
            {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void YeildTest031()
        {
            IEnumerable<YeildExecise.Vector> vectors = GetVectors();
            foreach (var item in vectors)
            {
                item.X = 4;
                item.Y = 4;
            }

            foreach (var item in vectors)
            {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void YeildTest032()
        {
            IEnumerable<YeildExecise.Vector> vectors = GetVectors();
            foreach (var item in vectors)
            {
                item.X = 4;
                item.Y = 4;
            }

            vectors = GetVectors().ToList();
            foreach (var item in vectors)
            {
                Console.WriteLine(item);
            }
        }
        
        private IEnumerable<YeildExecise.Vector> GetVectors()
        {
            yield return new YeildExecise.Vector(1, 1);
            yield return new YeildExecise.Vector(2, 3);
            yield return new YeildExecise.Vector(3, 3);
        }

        [Test]
        public void YeildTest04()
        {
            IEnumerable<YeildExecise.Vector> vectors = GetVectorsNormal();
            foreach (var item in vectors)
            {
                item.X = 4;
                item.Y = 4;
            }

            foreach (var item in vectors)
            {
                Console.WriteLine(item);
            }
        }

        private List<YeildExecise.Vector> GetVectorsNormal()
        {
            return new List<YeildExecise.Vector>
            {
                new YeildExecise.Vector(1, 1),
                new YeildExecise.Vector(1, 2),
                new YeildExecise.Vector(1, 3),
            };
        }

        [Test]
        public void YeildTest05()
        {
            IEnumerable<string> items = GetItems();
            Console.WriteLine("Begin to iterate the collection.");
            var ret = items.ToList();
        }

        private IEnumerable<string> GetItems()
        {
            Console.WriteLine("Begin to invoke GetItems(1)");
            Console.WriteLine("Begin to invoke GetItems(1)");
            yield return "1";

            Console.WriteLine("Begin to invoke GetItems(2)");
            yield return "2";

            Console.WriteLine("Begin to invoke GetItems(3)");
            Console.WriteLine("Begin to invoke GetItems(3)");
            Console.WriteLine("Begin to invoke GetItems(3)");
            yield return "3";
        }
    }
}