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
    public class HashtableExeciseTests
    {
        [Test]
        public void SimpleHashTest()
        {
            // given
            var hte = new HashtableExecise();

            string[] names = new string[99];
            string name;
            string[] someNames =
            {
                "David", "Jennifer", "Donnie", "Mayo", "Raymond", "Bernica", "Mike", "Clayton",
                "Beata", "Michael"
            };
            int hashVal;

            // when
            for (int i = 0; i < 10; i++)
            {
                name = someNames[i];
                hashVal = hte.SimpleHash(name, names);
                names[hashVal] = name;
            }
            hte.ShowDistrib(names);
        }
    }
}