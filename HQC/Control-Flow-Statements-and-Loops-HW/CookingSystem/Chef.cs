namespace CookingSystem
{
    public class Chef
    {   
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Carrot GetCarrot()
        {
            var carrot = new Carrot();

            return carrot;
        }

        private Bowl GetBowl()
        {
            var bowl = new Bowl();

            return bowl;
        }

        private Potato GetPotato()
        {
            var potato = new Potato();

            return potato; 
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }
    }
}
