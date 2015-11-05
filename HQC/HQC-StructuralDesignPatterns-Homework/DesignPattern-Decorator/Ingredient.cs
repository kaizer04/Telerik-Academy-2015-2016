using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Decorator
{
    public abstract class Ingredient: FastFood
    {
        protected FastFood FastFood { get; set; }

        protected Ingredient(FastFood ff)
        {
            FastFood = ff;
        }
    }
}
