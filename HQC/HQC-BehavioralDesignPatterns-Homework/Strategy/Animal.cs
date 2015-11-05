using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPK_15_DesignPatterns.Strategy
{
    public class Animal
    {
        protected IFlys flyingType;

        public string Name { get; set; }

        public double Height { get; set; }

        public double Weight{get; set;}
   
        public string Sound{get; set; }

        public string TryToFly()
        {
            return flyingType.Fly();
        }

        public void SetFlyingAbility(IFlys newFlyType)
        {
            flyingType = newFlyType;
        }
    }
}