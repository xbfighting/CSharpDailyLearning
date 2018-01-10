using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStudy
{

    #region base

    /// <summary>
    /// 声明泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPair<T>
    {
        T First { get; set; }
        T Second { get; set; }
    }

    /// <summary>
    /// 实现泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Pair<T> : IPair<T>
    {
        private T _First;
        private T _Second;

        public T First
        {
            get { return _First; }
            set { _First = value; }
        }

        public T Second
        {
            get { return _Second; }
            set { _Second = value; }
        }

        /// <summary>
        /// Struct的构造器必须对全部的字段进行初始化
        /// </summary>
        /// <param name="first"></param>
        public Pair(T first)
        {
            _First = first;
            // 默认值指定
            _Second = default(T);
        }

        public Pair(T first, T second)
        {
            _First = first;
            _Second = second;
        }
    }

    #endregion

    #region Senior

    /// <summary>
    /// 接口声明
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T>
    {
        IContainer<T> Items { get; set; }
    }

    /// <summary>
    /// 在类中多次实现一个接口
    /// </summary>
    public class Person : IContainer<Address>, IContainer<Email>, IContainer<Phone>
    {
        IContainer<Address> IContainer<Address>.Items { get; set; }
        IContainer<Email> IContainer<Email>.Items { get; set; }
        IContainer<Phone> IContainer<Phone>.Items { get; set; }
    }

    public class Address
    {
        //..
    }

    public class Email
    {
        //..
    }

    public class Phone
    {
        //..
    }
    #endregion
}
