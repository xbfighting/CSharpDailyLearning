//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAndOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClassAndOO.Tests
{
    [TestFixture]
    public class NewAndOverrideTests
    {

        [Test]
        public void Test_Override()
        {
            // given
            string result = "B1";

            // when
            B1 b1 = new B1();

            // then
            Assert.AreSame(result, b1.Print());
        }

        [Test]
        public void Test_New()
        {
            // given
            string result = "B2";
            
            // when
            B2 b2 = new B2();
            
            // then
            Assert.AreSame(result, b2.Print());
        }

        [Test]
        public void Test_Override_InitBase()
        {
            // given
            string result = "B1";

            // when
            A ab1 = new B1();

            // then
            Assert.AreSame(result, ab1.Print());
        }

        [Test]
        public void Test_New_InitBase()
        {
            // given
            string result = "A";

            // when
            A ab2 = new B2();

            // then
            Assert.AreSame(result, ab2.Print());
        }
    }
}