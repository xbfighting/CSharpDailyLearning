using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualKeywords
{
    public class YeildExecise
    {
        /*
           Yield has two great uses:
           1、It helps to provide custom iteration without creating temp collections.
           2、It helps to do stateful iteration.
         */
        public IEnumerable<int> Integers()
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

        public IEnumerable<int> IntegerGenerator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                // yield 是一个语法糖，它的本质是为我们实现 IEnumerator 接口。
                yield return i;
            }
        }

    }
}
