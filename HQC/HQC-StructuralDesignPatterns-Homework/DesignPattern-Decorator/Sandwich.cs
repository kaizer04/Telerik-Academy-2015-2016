using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    class Sandwich : FastFood
    {
        public override decimal Cost()
        {
            return 2.5m;
        }
    }
}
