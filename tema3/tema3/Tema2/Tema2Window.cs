using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Drawing;

namespace tema3.Tema2
{
    public class Tema2Window : GameWindow
    {
        const float rotation_speed = 180.0f;
        float angle;
        bool showPy = true;
        bool rotatecube = true;
        int nr_apasari = 0;
        float offset = 0;
        KeyboardState lastKeyPress;

        // Constructor.
        public Tema2Window() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.GreenYellow);
            GL.Enable(EnableCap.DepthTest);
        }

        /**Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
           ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD()!
           Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
           diferite). */
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == OpenTK.Input.Key.Escape)
            {
                Exit();
                return;

            }
            else if (e.Key == OpenTK.Input.Key.A)
            {
                nr_apasari++;
                if (nr_apasari == 2)
                {

                    rotatecube = !rotatecube;
                    nr_apasari = 0;
                }


            }
            else if (e.Key == OpenTK.Input.Key.B)
            {
                if (showPy == true)
                {
                    showPy = false;
                }
                else
                {
                    showPy = true;
                }
            }
        }
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            Console.WriteLine(e.X.ToString());
            offset = e.X / 50;
        }
        /** Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
            automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc. */

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();
            lastKeyPress = keyboard;



        }

        /** Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME().
            Parametrul de intrare "e" conține informatii de timing pentru randare. */
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            if (rotatecube == true)
            {
                angle += rotation_speed * (float)e.Time;
                GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            }
            // Exportăm controlul randării obiectelor către o metodă externă (modularizare).
            if (showPy == true)
            {
                DrawPyramid();




            }

            SwapBuffers();

        }


        protected void DrawPyramid()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex3(0 + offset, 10, 0);
            GL.Vertex3(-10 + offset, -10, 10);
            GL.Vertex3(10 + offset, -10, 10);

            // Fața din stânga
            GL.Color3(Color.Green);
            GL.Vertex3(0 + offset, 10, 0);
            GL.Vertex3(-10 + offset, -10, -10);
            GL.Vertex3(-10 + offset, -10, 10);

            // Fața din dreapta
            GL.Color3(Color.Blue);
            GL.Vertex3(0 + offset, 10, 0);
            GL.Vertex3(10 + offset, -10, 10);
            GL.Vertex3(10 + offset, -10, -10);

            // Fața din spate
            GL.Color3(Color.Yellow);
            GL.Vertex3(0 + offset, 10, 0);
            GL.Vertex3(10 + offset, -10, -10);
            GL.Vertex3(-10 + offset, -10, -10);


            GL.End();
        }
    }
}
