using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    class Pizza : FastFood
    {
        public override decimal Cost()
        {
            return 5;
        }
    }
}
