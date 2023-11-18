using OpenTK.Graphics.OpenGL;

using System.Drawing;

namespace tema3.Tema4
{
    public class Axes
    {
        public const int XYZ_SIZE = 75;

        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);

            // Ox
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(XYZ_SIZE, 0, 0);

            // Oy.
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0);

            // Oz.
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }
    }
}
