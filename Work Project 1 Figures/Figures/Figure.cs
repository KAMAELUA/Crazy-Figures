using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using Work_Project_1_Figures.Events;
using Work_Project_1_Figures.Interfaces;

namespace Work_Project_1_Figures.Figures
{
    [ Serializable,
        XmlInclude(typeof(Triangle)),
        XmlInclude(typeof(Circle)),
        XmlInclude(typeof(CustomRectangle)),
        KnownType(typeof(Triangle)), 
        KnownType(typeof(Circle)), 
        KnownType(typeof(CustomRectangle))]
    public abstract class Figure : IMovable, IDrawable
    {
        private bool IsOnIntersectionState = false;
        [DataMember]
        public Boolean isOnMove = false;

        [DataMember]
        public int argbColor;
        
        public Figure(){ }
        
        public abstract void Move(Size maxPoint);
        public abstract void Draw(Graphics g);
        public abstract RectangleF GetOuterFigureRectangle();

        public event EventHandler<IntersectionEventArgs> OnStartsIntersect;
        public event EventHandler<IntersectionEventArgs> OnIntersection;
        public event EventHandler<IntersectionEventArgs> OnEndsIntersect;

        private List<Figure> intersectsWith = new List<Figure>();

        public virtual void NowIntersects(Figure figure)
        {
            IntersectionEventArgs e = new IntersectionEventArgs(figure);
            if(!intersectsWith.Contains(figure))
            {
                StartIntersects(figure);
            }
            EventHandler<IntersectionEventArgs> tempProgress = Volatile.Read(ref OnIntersection);

            if (tempProgress != null) tempProgress(this, e);
        }

        private void StartIntersects(Figure figure)
        {
            EventHandler<IntersectionEventArgs> tempStart = Volatile.Read(ref OnStartsIntersect);
            IntersectionEventArgs e = new IntersectionEventArgs(figure);
            if (tempStart != null) tempStart(this, e);
            intersectsWith.Add(figure);
        }

        public void NotIntersects(Figure figure)
        {
            if(intersectsWith.Contains(figure))
            {
                IntersectionEventArgs evnt = new IntersectionEventArgs(figure);
                intersectsWith.Remove(figure);

                EventHandler<IntersectionEventArgs> tempEnd = Volatile.Read(ref OnEndsIntersect);

                if (tempEnd != null) tempEnd(this, evnt);
            }
        }

        void IMovable.Test()
        {
            Console.WriteLine("I am Test() from IMovable");
        }

        void IDrawable.Test()
        {
            Console.WriteLine("I am Test() from IDrawable");
        }

        void Test()
        {

        }
    }
}
