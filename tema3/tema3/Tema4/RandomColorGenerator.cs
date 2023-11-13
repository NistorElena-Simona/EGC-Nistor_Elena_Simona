using System;
using System.Drawing;

namespace tema3.Tema4
{
    public class RandomColorGenerator
    {
        private Random random;

        public RandomColorGenerator()
        {
            random = new Random();
        }

        /*
        3. Implementați un mecanism de modificare a culorilor (randomizare sau
        încărcare din paletă predefinită) pentru o clasă ce permite desenarea
        unui cub în spațiul 3D.
         */
        public Color Generate()
        {
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);

            Color color = Color.FromArgb(red, green, blue);

            return color;
        }

    }
}
