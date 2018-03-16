using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Delegate.Tests
{
    [TestFixture]
    public class CaptureVariableTests
    {
        /*
         * 在闭包和 for 循环一起使用时，如果多个委托捕捉到了同一个变量，则会有两种情况：
         * 1、捕捉到了同一个变量仅有的一个实例；
         * 2、捕捉到同一个变量，但每个委托拥有自己的一个实例。
         */


        /// <summary>
        /// 1、捕捉到了同一个变量仅有的一个实例
        /// </summary>
        [Test]
        public void Test_CaptureVariable_01()
        {
            // given
            int copy;
            List<Action> actions = new List<Action>();

            for (int i = 0; i < 10; i++)
            {
                copy = i;
                actions.Add(() => Console.WriteLine(copy));
            }

            // when
            foreach (var action in actions)
            {
                action();
            }

            // then

            // 输出10个9
        }

        /// <summary>
        /// 2、捕捉到同一个变量，但每个委托拥有自己的一个实例
        /// </summary>
        [Test]
        public void Test_CaptureVariable_02()
        {
            // given
            int copy;
            List<Action> actions = new List<Action>();

            for (int i = 0; i < 10; i++)
            {
                copy = i;
                int copyTmp = copy;
                actions.Add(() => Console.WriteLine(copyTmp));
            }

            // when
            foreach (var action in actions)
            {
                action();
            }

            // then

            // 输出 0到9
        }

        /// <summary>
        /// 1和2混合的情况
        /// </summary>
        [Test]
        public void Test_CaptureVariable_03()
        {
            // given
            int copy;
            List<Action> actions = new List<Action>();

            for (int i = 0; i < 10; i++)
            {
                copy = i;
                int copyTmp = copy;
                actions.Add(
                    () =>
                    {
                        Console.WriteLine($"{copy}, {copyTmp}");
                        copyTmp++;
                    }
                );
            }

            // when
            foreach (var action in actions)
            {
                action();
            }

            // 输出 
            // 9 0
            // 9 1
            // ...
            // 9 9
            
            actions[0](); // 9 1
            actions[0](); // 9 2
            actions[0](); // 9 3

            actions[1](); // 9 2
            actions[1](); // 9 3
            actions[1](); // 9 4

            // then
        }

        /// <summary>
        /// foreach
        /// </summary>
        [Test]
        public void Test_CaptureVariable_04()
        {
            // given
            int copy;
            List<Action> actions = new List<Action>();

            var values = new List<string> {"a", "b", "c"};
            foreach (var item in values)
            {
                // C# 5.0 输出a b c
                actions.Add(() => Console.WriteLine(item));
            }

            // when
            foreach (var action in actions)
            {
                action();
            }

            // then

            // 输出10个9
        }
    }
}