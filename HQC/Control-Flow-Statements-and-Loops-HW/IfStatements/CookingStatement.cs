namespace IfStatements
{
    public class CookingStatement
    {
        public static void Main
        {
        }

        public static void CookPotato()
        {
            var potato = new Potato();

            if (potato != null) 
            {
                if (potato.HasBeenPeeled && potato.IsFresh)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Potato potato)
        {
            // ...
        } 
    }
}