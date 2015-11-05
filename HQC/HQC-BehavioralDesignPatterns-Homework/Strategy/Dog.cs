namespace KPK_15_DesignPatterns.Strategy
{
    public class Dog : Animal
    {
        public Dog()
        {
            flyingType = new CantFly();
        }
    }
}
