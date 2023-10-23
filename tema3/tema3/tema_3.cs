using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace tema3
{
    internal class tema_3 : GameWindow
    {
        //lab3 ex8
        private float amountX = 0f;
        private float amountZ = 0f;
        private Vector3 color = Vector3.Zero;//vector folosit pe post de culoare
        //constructor
        public tema_3():base(800, 600)
        {
            VSync = VSyncMode.On;
            KeyDown += OnKeyPress;
            MouseMove += OnMouseMove;

        }

        //asteapta sa apesi taste
        private void OnKeyPress(object sender, KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    color.X += 0.01f;
                    color.Y += 0.01f;
                    color.Z+=0.01f;
                    break;
            }
            
        }

        //la miscarea mouse-ului se va modifica pozitia
        private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
           
                amountX = e.X - Width / 2;
                amountZ= e.Y - Height / 2;

                amountX /= 10;
                amountZ /= 10;

                //Console.WriteLine($"{amountX}X {cameraYOffset}Y");
            
        }
        //se apeleaza cand se incarca proiectul
        protected override void OnLoad(EventArgs e)
        {
         base.OnLoad(e);
            GL.ClearColor(Color.Sienna);
        }
        //pentru modificarea dimensiunii ferestrei
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }
        //logic joc
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
        }
        //desenarea obiectului pe ecran
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 lookat = Matrix4.LookAt(15+amountX, 50, 15+amountZ, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(color);
            GL.Vertex3(-0.0f, -0f, -0.0f);
            GL.Vertex3(-10.0f, 10.0f, -11.0f);
            GL.Vertex3(10f, 0.0f, -11.0f);
            GL.End();


            SwapBuffers();
        }
    }
}
