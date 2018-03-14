//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Assert = NUnit.Framework.Assert;

namespace Delegate.Tests
{
    [TestFixture]
    public class PeopleTests
    {
        [Test]
        public void PeopleTest()
        {
            // given
            Person[] pArray =
            {
                new Person {FirstName = "F1", LastName = "L1"}, 
                new Person {FirstName = "F2", LastName = "L2"}, 
                new Person {FirstName = "F3", LastName = "L3"}, 
            };
            int excepted = 3;
            int result = 0;

            // when
            var people = new People(pArray);
            foreach (var item in people)
            {
                result++;
            }

            // then
            Assert.AreEqual(excepted, result);
        }
    }
}