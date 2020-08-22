using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Grafica_Project.Negocio;
using System.Collections.Generic;

namespace Grafica_Project
{
    class Window : GameWindow
    {

        //atributos
        List<Objeto> casa = new List<Objeto>();


        //constructor
        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            casa.Add(new Techo());
            casa.Add(new Pared());
        }



        //para la primera vez que corremos el programa
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //cargar Matrices
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Width / Height, 0.1f, 100.0f);
            Matrix4 model = Matrix4.Identity;

            //posicion de la camara
            Vector3 cameraPosition = new Vector3(3.0f, 1.0f, 3.0f);
            Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

            Matrix4 view = Matrix4.LookAt(cameraPosition, target, up);



            foreach (Objeto parte in casa)
            {
                parte.setMatrices(model, view, projection);
            }
            


            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            //dibujar
            foreach (Objeto parte in casa)
            {
                parte.dibujar();
            }


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);



            base.OnResize(e);
        }


        //para cerrar el programa
        protected override void OnUnload(EventArgs e)
        {
            foreach (Objeto parte in casa)
            {
                parte.destroy();
            }
            base.OnUnload(e);
        }
    }
}

