using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovariantContravariant
{
    public abstract class Animal
    {
        
    }

    public class Dog : Animal
    {
        
    }

    //public interface IMyList<in T>
    public interface IMyList<out T>
    {
        // in 修饰 T, 为逆变
        T GetElement();

        // out 修饰 T, 为协变 只能用做参数，不能修改
        //void Change(T t);
    }

    public class MyList<T> : IMyList<T>
    {
        public T GetElement()
        {
            return default(T);
        }

        //public void Change(T t)
        //{

        //}
    }
}
