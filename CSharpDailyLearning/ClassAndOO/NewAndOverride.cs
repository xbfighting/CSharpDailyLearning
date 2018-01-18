using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndOO
{
    public class A
    {
        public virtual string Print()
        {
            return "A";
        }
    }

    public class B1 : A
    {
        public override string Print()
        {
            return "B1";
        }
    }

    public class B2 : A
    {
        public new string Print()
        {
            return "B2";
        }
    }
}
