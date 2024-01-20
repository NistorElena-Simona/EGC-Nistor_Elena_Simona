using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SphereRotation
{
    class Program : GameWindow
    {
      
        private float triangleRotationAngle = 0.0f;



        private float rotationAngle = 0.0f;
        private float orbitAngle = 0.0f;
        private float orbitRadius = 3.0f;
        


        private float satelliteSphereOrbitRadius = 2.0f;
        private float satelliteSphereOrbitAngle = MathHelper.PiOver2;


        static void Main()
        {
            using (var game = new Program())
            {
                game.Run(60.0);
            }
        }

        public Program() : base(800, 600, GraphicsMode.Default, "Sphere Rotation") { }

        private void DrawSphere(float radius, int slices, int stacks)
        {
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < stacks; i++)
            {
                double lat0 = Math.PI * (-0.5 + (double)(i) / stacks);
                double z0 = Math.Sin(lat0);
                double zr0 = Math.Cos(lat0);

                double lat1 = Math.PI * (-0.5 + (double)(i + 1) / stacks);
                double z1 = Math.Sin(lat1);
                double zr1 = Math.Cos(lat1);

                for (int j = 0; j < slices; j++)
                {
                    double lng0 = 2 * Math.PI * (double)(j) / slices;
                    double x0 = Math.Cos(lng0);
                    double y0 = Math.Sin(lng0);

                    double lng1 = 2 * Math.PI * (double)(j + 1) / slices;
                    double x1 = Math.Cos(lng1);
                    double y1 = Math.Sin(lng1);

                    GL.Vertex3(radius * x0 * zr0, radius * y0 * zr0, radius * z0);
                    GL.Vertex3(radius * x0 * zr1, radius * y0 * zr1, radius * z1);
                    GL.Vertex3(radius * x1 * zr1, radius * y1 * zr1, radius * z1);
                    GL.Vertex3(radius * x1 * zr0, radius * y1 * zr0, radius * z0);
                }
            }
            GL.End();
        }




        private void DrawCube(float size)
        {
            float halfSize = size / 2;

            GL.Begin(PrimitiveType.Quads);

            // Front face
            GL.Vertex3(halfSize, halfSize, -halfSize);
            GL.Vertex3(-halfSize, halfSize, -halfSize);
            GL.Vertex3(-halfSize, -halfSize, -halfSize);
            GL.Vertex3(halfSize, -halfSize, -halfSize);

            // Back face
            GL.Vertex3(halfSize, halfSize, halfSize);
            GL.Vertex3(-halfSize, halfSize, halfSize);
            GL.Vertex3(-halfSize, -halfSize, halfSize);
            GL.Vertex3(halfSize, -halfSize, halfSize);

            // Left face
            GL.Vertex3(-halfSize, halfSize, -halfSize);
            GL.Vertex3(-halfSize, halfSize, halfSize);
            GL.Vertex3(-halfSize, -halfSize, halfSize);
            GL.Vertex3(-halfSize, -halfSize, -halfSize);

            // Right face
            GL.Vertex3(halfSize, halfSize, halfSize);
            GL.Vertex3(halfSize, halfSize, -halfSize);
            GL.Vertex3(halfSize, -halfSize, -halfSize);
            GL.Vertex3(halfSize, -halfSize, halfSize);

            // Top face
            GL.Vertex3(halfSize, halfSize, halfSize);
            GL.Vertex3(-halfSize, halfSize, halfSize);
            GL.Vertex3(-halfSize, halfSize, -halfSize);
            GL.Vertex3(halfSize, halfSize, -halfSize);

            // Bottom face
            GL.Vertex3(halfSize, -halfSize, -halfSize);
            GL.Vertex3(-halfSize, -halfSize, -halfSize);
            GL.Vertex3(-halfSize, -halfSize, halfSize);
            GL.Vertex3(halfSize, -halfSize, halfSize);

            GL.End();
        }

        private void DrawTriangle(float size)
        {
            float halfSize = size / 2;

            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex3(0, halfSize, -halfSize);
            GL.Vertex3(-halfSize, -halfSize, -halfSize);
            GL.Vertex3(halfSize, -halfSize, -halfSize);

            GL.End();
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 modelview = Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.UnitY);
            GL.LoadMatrix(ref modelview);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //rotationAngle += (float)e.Time * 1.5f;
            //orbitAngle += (float)e.Time * 0.5f;
            rotationAngle += (float)e.Time * 300.0f; // Ajustează această valoare pentru o rotație mai rapidă
            orbitAngle += (float)e.Time * 50.0f;

            triangleRotationAngle += (float)e.Time * 30.5f;


            satelliteSphereOrbitAngle += (float)e.Time * 0.8f;

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            GL.Color3(1.0f, 1.0f, 1.0f);
            // Desenează sfera principală
            //GL.PushMatrix();
            //GL.Rotate(rotationAngle, Vector3.UnitY);
            DrawSphere(1.0f, 32, 16);
            //GL.PopMatrix();


            // Schimbă culoarea pentru sfera principală
            GL.Color3(0.0f, 0.0f, 1.0f); // Culoarea albastră (RGB: 0, 0, 1)


            // Desenează sfera care se învârte în jurul celei principale
            GL.PushMatrix();
            GL.Rotate(orbitAngle, Vector3.UnitY);
            GL.Translate(orbitRadius, 0, 0);
            GL.Rotate(rotationAngle * 2, Vector3.UnitY);
            DrawSphere(0.2f, 16, 8);
            GL.PopMatrix();


            GL.Color3(1.0f, 1.0f, 0.0f); // Culoarea galbenă (RGB: 1, 1, 0)

            Matrix4 triangleTranslationMatrix = Matrix4.CreateTranslation(
                satelliteSphereOrbitRadius * (float)Math.Cos(satelliteSphereOrbitAngle),
                 satelliteSphereOrbitRadius * (float)Math.Sin(satelliteSphereOrbitAngle),
               0
            );

            GL.PushMatrix();
            GL.MultMatrix(ref triangleTranslationMatrix);
            GL.Rotate(triangleRotationAngle, Vector3.UnitZ);
            DrawTriangle(0.5f);
            GL.PopMatrix();




            GL.Color3(0.0f, 1.0f, 0.0f); // Culoarea verde (RGB: 0, 1, 0)

            Matrix4 satelliteSphereTranslationMatrix = Matrix4.CreateTranslation(
                satelliteSphereOrbitRadius * (float)Math.Cos(satelliteSphereOrbitAngle),
                0,
                satelliteSphereOrbitRadius * (float)Math.Sin(satelliteSphereOrbitAngle)
            );
            

            GL.PushMatrix();
            GL.MultMatrix(ref satelliteSphereTranslationMatrix);
            GL.Rotate(satelliteSphereOrbitAngle, Vector3.UnitX);
            DrawSphere(0.3f, 16, 8);
            GL.PopMatrix();


            



            SwapBuffers();
        }

       

    }
}
