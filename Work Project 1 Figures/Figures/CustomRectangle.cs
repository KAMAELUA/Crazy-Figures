using InformationLibrary;
using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Work_Project_1_Figures
{
    [Serializable, DataContract]
    public class CustomRectangle : Figure
    {
        [DataMember]
        public int size;
        [DataMember]
        public Rectangle figure;

        [DataMember]
        public Size motionVector;

        private Pen drawingPen
        {
            get { return new Pen(Color.FromArgb(argbColor)); }
        }

        public CustomRectangle()
        {
            Random R = new Random();

            size = R.Next(
                ConstantLibrary.RectangleSizeRange.MIN,
                ConstantLibrary.RectangleSizeRange.MAX);
            figure = new Rectangle(0, 0, size, size);
            motionVector = new Size(
                R.Next(ConstantLibrary.RectangleMotionVector.MIN, ConstantLibrary.RectangleMotionVector.MAX),
                R.Next(ConstantLibrary.RectangleMotionVector.MIN, ConstantLibrary.RectangleMotionVector.MAX));
            argbColor = Randomizer.GetRandomArgbColor();
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(drawingPen, figure);
        }

        public override void Move(Size maxPoint)
        {
            if (isOnMove)
            {
                if (IsCrossingXAxis(maxPoint))
                    motionVector.Width = -motionVector.Width;
                if (IsCrossingYAxis(maxPoint))
                    motionVector.Height = -motionVector.Height;

                Point rectangleLocation = figure.Location;
                figure.Location = Point.Add(rectangleLocation, motionVector);
            }
        }

        private bool IsCrossingYAxis(Size maxPoint)
        {
            float tmpTopPoint = figure.Top + motionVector.Height;
            float tmpBottomPoint = figure.Bottom + motionVector.Height;

            if (tmpTopPoint < 0 || tmpBottomPoint > maxPoint.Height)
                return true;
            else return false;
        }

        private bool IsCrossingXAxis(Size maxPoint)
        {
            float tmpLeftPoint = figure.Left + motionVector.Width;
            float tmpRightPoint = figure.Right + motionVector.Width;

            if (tmpLeftPoint < 0 || tmpRightPoint > maxPoint.Width)
                return true;
            else return false;
        }
    }
}
