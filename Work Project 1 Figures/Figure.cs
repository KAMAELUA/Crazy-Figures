using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Work_Project_1_Figures
{
    [Serializable(),
        KnownType(typeof(Triangle)), KnownType(typeof(Circle)), KnownType(typeof(CustomRectangle))]
    public abstract class Figure
    {
        public Boolean isOnMove = false;
        public abstract Color FigureColor
        {
            get;
            set;
        }
        public abstract void Move(Size maxPoint);
        public abstract void Draw(Graphics g);

    }
}
