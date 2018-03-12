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
    public class DelegateActionFunTests
    {
        [Test]
        public void CompareTest()
        {
            // given 
            int a = 1;
            int b = 2;
            Func<int, int, bool> ruleFunc = DelegateActionFun.rule1;
            bool expected = false;

            // when
            var result = DelegateActionFun.Compare(a, b, ruleFunc);

            // then 
            Console.WriteLine("Int compare result:{0}", result);

            Assert.AreEqual(expected, result);
        }
    }
}