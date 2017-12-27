using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnumOperator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumOperator.Tests
{
    [TestClass()]
    public class EnumOperatorTests
    {
        [TestMethod()]
        public void GetEnumDescriptionByInt_InEnum_Test()
        {
            var description = EnumOperator.GetEnumDescriptionByInt(1);
            Assert.IsTrue(description == PackageStoredTypeEnum.Normal.GetDescription());
        }

        [TestMethod()]
        public void GetEnumDescriptionByInt_OutOfEnum_Test()
        {
            var description = EnumOperator.GetEnumDescriptionByInt(10);
            Assert.IsTrue(description == PackageStoredTypeEnum.UnKnown.GetDescription());
        }

        [TestMethod()]
        public void GetEnumDescriptionByInt_OutOfEnumEx_Test()
        {
            var description = EnumOperator.GetEnumDescriptionByInt(-1);
            Assert.IsTrue(description == PackageStoredTypeEnum.UnKnown.GetDescription());
        }

        [TestMethod()]
        public void GetEnumDescriptionByInt_Null_Test()
        {
            var description = EnumOperator.GetEnumDescriptionByInt(null);
            Assert.IsTrue(description == PackageStoredTypeEnum.UnKnown.GetDescription());
        }
    }
}