using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStudy
{
    internal interface IPari<TFirst, TSecond>
    {
        TFirst First { get; set; }
        TSecond Second { get; set; }
    }

    public struct Pari<TFirst, TSecond> : IPari<TFirst, TSecond>
    {
        private TFirst _First;
        private TSecond _Second;

        public Pari(TFirst first, TSecond second)
        {
            _First = first;
            _Second = second;
        }

        public TFirst First
        {
            get { return _First; }
            set { _First = value; }
        }

        public TSecond Second
        {
            get { return _Second; }
            set { _Second = value; }
        }
    }

    public class Test
    {
        public void TestMethid()
        {
            Pari<int, string> pari01 = new Pari<int, string>(1914, "1914 string");
            Console.WriteLine($"{pari01.First}:{pari01.Second}");
        }
    }
}
