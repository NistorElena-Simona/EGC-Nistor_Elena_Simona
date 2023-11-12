using OpenTK.Input;
using OpenTK;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace tema3
{
    class citire_fisier : GameWindow
    {
        KeyboardState previousKeyboard;
        private ColorHandler colorhandler;
        private Cam3D camera;
        private Cube cube;
        private Axes axes;

        // Constructor for the 3D window
        public citire_fisier() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            camera = new Cam3D();
            axes = new Axes();

            cube = new Cube("./../../coordonate.txt");

           
           
        }

        // Method called when the window is loaded
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Set the clear color, enable depth testing, and set polygon smoothing hint
            GL.ClearColor(Color.LightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        // Method called when the window is resized
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Set viewport and projection matrix based on window dimensions
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            // Set camera position and orientation
            camera.SetCamera();
        }

        // Method called to update the frame
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            // Handle keyboard and mouse input
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            // Control camera using mouse input
            camera.ControlCamera(thisMouse);
            cube.SetColor();

            // Check for key presses and perform corresponding actions
            if (thisKeyboard[Key.Escape])
            {
                // Exit the application when Escape key is pressed
                Exit();
                return;
            }
            else if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
               
                
            }


            // Update the previous keyboard state for the next frame
            previousKeyboard = thisKeyboard;
        }

        // Method called to render the frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            // Clear the color and depth buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Draw the coordinate axes and the triangles
            axes.Draw();
            cube.Draw();

            // Swap the front and back buffers to display the rendered image
            SwapBuffers();
        }

        // Method to draw the coordinate axes



      
        

    }
}
