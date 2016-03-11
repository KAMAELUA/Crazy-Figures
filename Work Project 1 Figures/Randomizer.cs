using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Project_1_Figures
{
    public static class Randomizer
    {
        public static int GetRandomArgbColor()
        {
            Random R = new Random();
            int red = R.Next(0, 255);
            int green = R.Next(0, 255);
            int blue = R.Next(0, 255);

            return Color.FromArgb(255, red, green, blue).ToArgb();
        }
    }
}
