using OpenTK.Input;
using OpenTK;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Drawing;
using System.Threading;
using System.Windows.Media;

using OpenTK.Graphics.OpenGL;

using Color = System.Drawing.Color;


/* 
 
 *
 **                  NISTOR ELENA SIMONA
 *                      GRUPA 3131B 
 *                 REZOLVARE LABORATOR 2 EGC
 * 
 */
namespace Nistor_L2
{
    internal class SimpleWindow3D : GameWindow
    {


        const float rotation_speed = 180.0f;
        float angle;
        bool showPy = true;
        bool rotatecube = true;
        int nr_apasari=0;
        float offset= 0;
        KeyboardState lastKeyPress;

        // Constructor.
        public SimpleWindow3D() : base(800, 600)
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
            if (e.Key==OpenTK.Input.Key.Escape)
            {
                Exit();
                return;

            }
            else if (e.Key ==OpenTK.Input.Key.A)
            {
                nr_apasari++;
                if (nr_apasari == 2)
                {

                    rotatecube = !rotatecube;
                    nr_apasari = 0;
                }


            }
            else if (e.Key==OpenTK.Input.Key.B)
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


            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, mai ales pentru gaming - gamepads, joysticks, etc.).
          

            //else if (keyboard[OpenTK.Input.Key.H] && !keyboard.Equals(lastKeyPress)) {
            // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacțieuman << calculator.
            // if (showCube == true) {
            //   showCube = false;
            //} else {
            //  showCube = true;
            //}
            //}
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




        /* private void DrawCube()
         {
             GL.Begin(PrimitiveType.Quads);

             GL.Color3(Color.Silver);
             GL.Vertex3(-1.0f, -1.0f, -1.0f);
             GL.Vertex3(-1.0f, 1.0f, -1.0f);
             GL.Vertex3(1.0f, 1.0f, -1.0f);
             GL.Vertex3(1.0f, -1.0f, -1.0f);

             GL.Color3(Color.Honeydew);
             GL.Vertex3(-1.0f, -1.0f, -1.0f);
             GL.Vertex3(1.0f, -1.0f, -1.0f);
             GL.Vertex3(1.0f, -1.0f, 1.0f);
             GL.Vertex3(-1.0f, -1.0f, 1.0f);

             GL.Color3(Color.Moccasin);

             GL.Vertex3(-1.0f, -1.0f, -1.0f);
             GL.Vertex3(-1.0f, -1.0f, 1.0f);
             GL.Vertex3(-1.0f, 1.0f, 1.0f);
             GL.Vertex3(-1.0f, 1.0f, -1.0f);

             GL.Color3(Color.IndianRed);
             GL.Vertex3(-1.0f, -1.0f, 1.0f);
             GL.Vertex3(1.0f, -1.0f, 1.0f);
             GL.Vertex3(1.0f, 1.0f, 1.0f);
             GL.Vertex3(-1.0f, 1.0f, 1.0f);

             GL.Color3(Color.PaleVioletRed);
             GL.Vertex3(-1.0f, 1.0f, -1.0f);
             GL.Vertex3(-1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, 1.0f, -1.0f);

             GL.Color3(Color.ForestGreen);
             GL.Vertex3(1.0f, -1.0f, -1.0f);
             GL.Vertex3(1.0f, 1.0f, -1.0f);
             GL.Vertex3(1.0f, 1.0f, 1.0f);
             GL.Vertex3(1.0f, -1.0f, 1.0f);

             GL.End();
         }*/
        protected void DrawPyramid()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex3(0+offset, 10, 0);
            GL.Vertex3(-10+offset, -10, 10);
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
