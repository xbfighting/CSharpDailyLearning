using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CovariantContravariant
{
    class Program
    {
        // in 标记的委托
        public delegate void Action<in T>(T obj);

        static void Main(string[] args)
        {
            Dog aDog = new Dog();
            // succeed Dog 继承自 Animal 所以转换正常（协变）
            Animal aAnimal = aDog;

            List<Dog> listDogs = new List<Dog>();
            // error List<Dog> 并没有继承自 List<Animal> 所以转换失败
            //List<Animal> listAnimals = listDogs;

            // 复杂的强制类型转换
            List<Animal> listAnimals2 = listDogs.Select(d => (Animal) d).ToList();


            #region 协变 OUT
            
            /*
             * [TypeDependencyAttribute("System.SZArrayHelper")]
             * public interface IEnumerable<out T> : IEnumerable
             * 
             * T 用 out 标记，所以代表了输出，也就是只能作为结果返回
            */
            IEnumerable<Dog> someDogs = new List<Dog>();
            // 因为T只能做结果返回，所以T不会被修改， 编译器就可以推断下面的语句强制转换合法
            IEnumerable<Animal> someAnimals = someDogs;

            #endregion

            #region 逆变 IN

            Action<Animal> actionAnimal = new Action<Animal>(a =>
            {
                /*让动物叫*/
                Console.WriteLine("让动物叫");
            });
            /*
             * In 关键字：逆变，代表输入，代表着只能被使用，不能作为返回值，
             * 所以C#编译器可以根据in关键字推断这个泛型类型只能被使用，
             * 所以Action<Dog> actionDog = actionAnimal;可以通过编译器的检查。
             */
            Action<Dog> actionDog = actionAnimal;
            actionDog(aDog);

            #endregion

            #region 协变2 OUT

            IMyList<Dog> myDogs = new MyList<Dog>();
            IMyList<Animal> myAnimals = myDogs;

            #endregion

            #region 逆变2 IN

            //IMyList<Animal> myAnimals = new MyList<Animal>();
            //IMyList<Dog> myDogs = myAnimals;

            #endregion

        }
    }
}
