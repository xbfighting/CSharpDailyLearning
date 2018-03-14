using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    //  IEnumerable的缺点
    //  IEnumerable 功能有限，不能插入和删除。
    //  访问 IEnumerable 只能通过迭代，不能使用索引器。迭代显然是非线程安全的，每次 IEnumerable 都会生成新的 IEnumerator，从而形成多个互相不影响的迭代过程。
    //  在迭代时，只能前进不能后退。新的迭代不会记得之前迭代后值的任何变化。

    public class People : IEnumerable
    {
        private readonly Person[] _people;

        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            // 借用 PeopleEnumerator 实现 IEnumerable.GetEnumerator
            //return new PeopleEnumerator(_people);

            // yield 是一个语法糖，它的本质是为我们实现 IEnumerator 接口。
            // yield 会自动实现 MoveNext,Reset,Current
            foreach (var item in _people)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// 实现 IEnumerator
    /// </summary>
    public class PeopleEnumerator : IEnumerator
    {
        public Person[] Peoples;

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return Peoples[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        private int _position = -1;

        public PeopleEnumerator(Person[] peoples)
        {
            Peoples = peoples;
        }

        /// <summary>
        /// MoveNext
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            _position++;
            return _position < Peoples.Length;
        }

        /// <summary>
        /// Reset
        /// </summary>
        public void Reset() => _position = -1;
    }


    /// <summary>
    /// Person
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
