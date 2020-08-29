using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Grafica_Project.Negocio;
using OpenTK.Input;

namespace Grafica_Project
{
    class Window : GameWindow
    {

        //atributos
        Casa casa;


        //constructor
        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            casa = new Casa();
        }



        //para la primera vez que corremos el programa
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //cargar Matrices
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Width / Height, 0.1f, 100.0f);

            //posicion de la camara
            Vector3 cameraPosition = new Vector3(0.0f, 1.5f, 4.0f);
            Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

            Matrix4 view = Matrix4.LookAt(cameraPosition, target, up);



            casa.setMatrices(view, projection);



            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            //dibujar
            casa.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            KeyboardState inputKey = Keyboard.GetState();
            
            if (this.Focused)
            {

                if (inputKey.IsKeyDown(Key.Escape))
                {
                    this.Exit();
                }

                if (inputKey.IsKeyDown(Key.S))
                {
                    //hacia atrás
                    casa.mover(new Vector3(0.0f, 0.0f, 0.05f));
                }

                if (inputKey.IsKeyDown(Key.W))
                {
                    //hacia adelante
                    casa.mover(new Vector3(0.0f, 0.0f, -0.05f));
                }

                if (inputKey.IsKeyDown(Key.D))
                {
                    //hacia derecha
                    casa.mover(new Vector3(0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Key.A))
                {
                    //hacia izquierda
                    casa.mover(new Vector3(-0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Key.Space))
                {
                    //hacia arriba
                    casa.mover(new Vector3(0.0f, 0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Key.ControlLeft))
                {
                    //hacia abajo
                    casa.mover(new Vector3(0.0f, -0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Key.Q))
                {
                    //mas grande
                    casa.scale(new Vector3(1.01f, 1.01f, 1.01f));
                }

                if (inputKey.IsKeyDown(Key.E))
                {
                    //mas pequeño
                    casa.scale(new Vector3(0.99f, 0.99f, 0.99f));
                }

                if (inputKey.IsKeyDown(Key.R))
                {
                    casa.rotarEnY(0.02f);
                }

                if (inputKey.IsKeyDown(Key.T))
                {
                    casa.rotarEnX(0.02f);
                }

                if (inputKey.IsKeyDown(Key.Y))
                {
                    casa.rotarEnZ(0.02f);
                }

                if (inputKey.IsKeyDown(Key.I))
                {
                    casa.puntoInicial();
                }

                if (inputKey.IsKeyDown(Key.O))
                {
                    casa.abrirCerrarPuerta(-0.02f);
                }

                if (inputKey.IsKeyDown(Key.Number5))
                {
                    casa.descapotar();
                }

            }

            base.OnUpdateFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);



            base.OnResize(e);
        }


        //para cerrar el programa
        protected override void OnUnload(EventArgs e)
        {
            casa.destroy();
            base.OnUnload(e);
        }
    }
}

