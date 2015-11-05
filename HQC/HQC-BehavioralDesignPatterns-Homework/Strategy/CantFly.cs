using System;

namespace KPK_15_DesignPatterns.Strategy
{
    public class CantFly : IFlys
    {
        public String Fly()
        {
            return "I can't fly";
        }
    }
}
