using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimosTime
{
    class PrimoCheck
    {
        public bool check(int a)
        {
            bool ver3, ver2;
            ver2 = ver3 = false;
            for (int b = 2; b <= a; b++)
            {
                if (a % b == 0 && a != b)
                {
                    ver3 = true;
                }
                if (a == b && ver3 == false)
                {
                    ver2 = true;
                }
            }
            if (ver2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
