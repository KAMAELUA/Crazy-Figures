using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Work_Project_1_Figures
{
    [Serializable(), DataContract]
    public class Triangle : Figure
    {
        [DataMember]
        public int size;
        [DataMember]
        private PointF A;
        [DataMember]
        private PointF B;
        [DataMember]
        private PointF C;
        [DataMember]
        private Size motionVector;
        [XmlIgnore]
        private Pen drawingPen
        {
            get
            {
                return new Pen(FigureColor);
            }
            set
            {

            }
        }
        [DataMember]
        int R_Channel;
        [DataMember]
        int G_Channel;
        [DataMember]
        int B_Channel;




        [XmlIgnore]
        public override Color FigureColor
        {
            get
            {
                return Color.FromArgb(255, R_Channel, G_Channel, B_Channel);
            }
            set
            {
                R_Channel = value.R;
                G_Channel = value.G;
                B_Channel = value.B;                
            }
        }

        public Triangle()
        {
            
            Random R = new Random();
            size = R.Next(80, 150);

            motionVector = new Size(R.Next(3, 15), R.Next(3, 15));

            A = new PointF(0, 0);
            B = new PointF();
            C = new PointF();

            B.X = size;
            B.Y = 0;

            C.X = size / 2;
            C.Y = (float)(size * Math.Cos(Math.PI / 6));

            FigureColor = GetRandomColor();
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

        private Color GetRandomColor()
        {
            Random R = new Random();
            int red = R.Next(0, 255);
            int green = R.Next(0, 255);
            int blue = R.Next(0, 255);

            return Color.FromArgb(255, red, green, blue);
        }
    }
}
