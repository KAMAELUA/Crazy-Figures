using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Project_1_Figures.Events
{
    public class IntersectionEventArgs : EventArgs
    {
        private readonly Figure intersectWith;

        public IntersectionEventArgs(Figure with)
        {
            intersectWith = with;
        }

        public Figure IntersectWith
        {
            get
            {
                return intersectWith;
            }
        }
    }
}
