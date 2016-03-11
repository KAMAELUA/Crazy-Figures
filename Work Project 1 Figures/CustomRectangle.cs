using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Project_1_Figures
{
    [Serializable()]
    public class CustomRectangle : Figure
    {
        private int size;
        private Rectangle figure;
        private Pen drawingPen;
        private Size motionVector;

        public CustomRectangle()
        {
            Random R = new Random();

            size = R.Next(80, 150);
            figure = new Rectangle(0, 0, size, size);
            motionVector = new Size(R.Next(3, 15), R.Next(3, 15));
            drawingPen = GetRandomPen();
        }

        public override Color FigureColor
        {
            get
            {
                return drawingPen.Color;
            }
            set
            {

            }
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

        private Pen GetRandomPen()
        {
            Random R = new Random();
            int red = R.Next(0, 255);
            int green = R.Next(0, 255);
            int blue = R.Next(0, 255);

            return new Pen(Color.FromArgb(255, red, green, blue));
        }
    }
}
