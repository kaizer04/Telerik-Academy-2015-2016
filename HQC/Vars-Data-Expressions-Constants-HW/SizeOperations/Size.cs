namespace SizeOperations
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Size GetRotatedSize(
            Size figureToRotate, double angleOfRotate)
        {
            var cosOfAngleOfRotate = Math.Abs(Math.Cos(angleOfRotate));
            var sinOfAngleOfRotate = Math.Abs(Math.Sin(angleOfRotate));

            var newWidth = (cosOfAngleOfRotate * figureToRotate.Width) + (sinOfAngleOfRotate * figureToRotate.Height);
            var newHeight = (sinOfAngleOfRotate * figureToRotate.Width) + (cosOfAngleOfRotate * figureToRotate.Height);
            
            var rotatedFigure = new Size(newWidth, newHeight);

            return rotatedFigure;
        }
    }
}
