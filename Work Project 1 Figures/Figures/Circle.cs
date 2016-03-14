using System;
using System.Drawing;
using System.Runtime.Serialization;
using InformationLibrary;
using Work_Project_1_Figures.Events;
using System.Threading;

namespace Work_Project_1_Figures
{
    [Serializable, DataContract]
    public class Circle : Figure
    {
        [DataMember]
        public int size;
        [DataMember]
        public RectangleF circleOuterRectangle;

        private Pen drawingPen
        {
            get { return new Pen(Color.FromArgb(argbColor)); }
        }


        [DataMember]
        private Size motionVector;

        public event EventHandler<IntersectionEventArgs> StartsIntersect;

        protected virtual void OnStartIntersect(IntersectionEventArgs e)
        {
            EventHandler<IntersectionEventArgs> temp = Volatile.Read(ref StartsIntersect);

            if (temp != null) temp(this, e);
        }

        public Circle()
        {
            Random R = new Random();

            size = R.Next(
                ConstantLibrary.CircleSizeRange.MIN,
                ConstantLibrary.CircleSizeRange.MAX);
            circleOuterRectangle = new RectangleF(0, 0, size, size);
            motionVector = new Size(
                R.Next(ConstantLibrary.CircleMotionVector.MIN, ConstantLibrary.CircleMotionVector.MAX),
                R.Next(ConstantLibrary.CircleMotionVector.MIN, ConstantLibrary.CircleMotionVector.MAX));
            argbColor = Randomizer.GetRandomArgbColor();
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(drawingPen, circleOuterRectangle);
        }

        public override void Move(Size maxPoint)
        {
            if (isOnMove)
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
    }
}
