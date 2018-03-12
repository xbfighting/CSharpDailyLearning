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
    public class EventTestTests
    {
        [Test]
        public void TestTest()
        {
            var e = new EventTest();
            e.Test();
        }
    }
}