using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Work_Project_1_Figures.Figures
{
    [ Serializable,
        XmlInclude(typeof(Triangle)),
        XmlInclude(typeof(Circle)),
        XmlInclude(typeof(CustomRectangle)),
        KnownType(typeof(Triangle)), 
        KnownType(typeof(Circle)), 
        KnownType(typeof(CustomRectangle))]
    public abstract class Figure
    {
        [DataMember]
        public Boolean isOnMove = false;

        [DataMember]
        public int argbColor;
        
        public Figure(){ }
        
        public abstract void Move(Size maxPoint);
        public abstract void Draw(Graphics g);

    }
}
