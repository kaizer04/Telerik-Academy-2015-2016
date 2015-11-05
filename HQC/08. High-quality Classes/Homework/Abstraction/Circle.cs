﻿namespace Abstraction
{
    using System;

    public class Circle : Figure, IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get 
            {
                return this.radius;
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius can not be <= 0!");
                }

                this.radius = value;
            }
        }
        
        public override double CalculatePerimeter()
        {   
            double perimeter = 2 * Math.PI * this.Radius;
        
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            
            return surface;
        }

        public override string ToString()
        {
            return "Circle:" + base.ToString();
        }
    }
}
