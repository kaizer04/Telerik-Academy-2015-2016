namespace Abstraction
{
    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("\nThe perimeter is {0:f2}.\nThe Area is {1:f2}.", this.CalculatePerimeter(), this.CalculateSurface());
        }
    }
}
