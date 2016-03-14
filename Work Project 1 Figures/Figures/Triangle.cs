using InformationLibrary;
using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Work_Project_1_Figures.Figures
{
    [Serializable, DataContract]
    public class Triangle : Figure
    {
        [DataMember]
        public int size;
        [DataMember]
        public PointF A;
        [DataMember]
        public PointF B;
        [DataMember]
        public PointF C;
        [DataMember]
        public Size motionVector;

        private Pen drawingPen
        {
            get
            {
                return new Pen(Color.FromArgb(argbColor));
            }
        }

        public Triangle()
        {
            Random R = new Random();
            size = R.Next(
                ConstantLibrary.TriangleSizeRange.MIN,
                ConstantLibrary.TriangleSizeRange.MAX);
            motionVector = new Size(
                R.Next(ConstantLibrary.CircleMotionVector.MIN, ConstantLibrary.CircleMotionVector.MAX),
                R.Next(ConstantLibrary.CircleMotionVector.MIN, ConstantLibrary.CircleMotionVector.MAX));

            A = new PointF(0, 0);
            B = new PointF(size, 0);
            C = new PointF(size/2, (float)(size * Math.Cos(Math.PI / 6)));

            argbColor = Randomizer.GetRandomArgbColor();
        }

        public override void Draw(Graphics g)
        {
            g.DrawLines(drawingPen, new Point[] { Point.Ceiling(A), Point.Ceiling(B), Point.Ceiling(C), Point.Ceiling(A) });
        }

        public override void Move(Size maxPoint)
        {
            if (isOnMove)
            {
                if (IsCrossingXAxis(maxPoint))
                    motionVector.Width = -motionVector.Width;
                if (IsCrossingYAxis(maxPoint))
                    motionVector.Height = -motionVector.Height;

                A = PointF.Add(A, motionVector);
                B = PointF.Add(B, motionVector);
                C = PointF.Add(C, motionVector);
            }
        }

        public override RectangleF GetOuterFigureRectangle()
        {
            return new RectangleF(A, new Size(size, Convert.ToInt32(C.Y)));
        }

        private Boolean IsCrossingXAxis(Size maxPoint)
        {
            PointF tmpA = PointF.Add(A, motionVector);
            PointF tmpB = PointF.Add(B, motionVector);
            if (tmpA.X < 0 || tmpB.X > maxPoint.Width)
            {
                return true;
            }
            else
                return false;
        }

        private Boolean IsCrossingYAxis(Size maxPoint)
        {
            PointF tmpA = PointF.Add(A, motionVector);
            PointF tmpC = PointF.Add(C, motionVector);
            if (tmpA.Y < 0 || tmpC.Y > maxPoint.Height)
            {
                return true;
            }
            else
                return false;
        }
    }
}
