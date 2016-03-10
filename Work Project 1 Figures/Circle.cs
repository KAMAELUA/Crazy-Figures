using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Work_Project_1_Figures
{
    [Serializable(), DataContract]
    class Circle : Figure
    {
        [DataMember]
        private int size;
        [DataMember]
        private RectangleF circleOuterRectangle;
        [DataMember]
        private Pen drawingPen;
        [DataMember]
        private Size motionVector;

        public Circle()
        {
            Random R = new Random();

            size = R.Next(80, 150);
            circleOuterRectangle = new RectangleF(0, 0, size, size);
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
            g.DrawEllipse(drawingPen, circleOuterRectangle);
        }

        public override void Move(Size maxPoint)
        {
            if(isOnMove)
            {
                if (IsCrossingXAxis(maxPoint))
                    motionVector.Width = -motionVector.Width;
                if (IsCrossingYAxis(maxPoint))
                    motionVector.Height = -motionVector.Height;

                PointF circleLocation = circleOuterRectangle.Location;
                circleOuterRectangle.Location = PointF.Add(circleLocation, motionVector);
            }
        }

        private bool IsCrossingYAxis(Size maxPoint)
        {
            float tmpTopPoint = circleOuterRectangle.Top + motionVector.Height;
            float tmpBottomPoint = circleOuterRectangle.Bottom + motionVector.Height;

            if (tmpTopPoint < 0 || tmpBottomPoint > maxPoint.Height)
                return true;
            else return false;
        }

        private bool IsCrossingXAxis(Size maxPoint)
        {
            float tmpLeftPoint = circleOuterRectangle.Left + motionVector.Width;
            float tmpRightPoint = circleOuterRectangle.Right + motionVector.Width;

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
