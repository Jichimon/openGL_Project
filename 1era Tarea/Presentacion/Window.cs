using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Grafica_Project.Negocio;

namespace Grafica_Project
{
    class Window : GameWindow
    {

        //atributos
        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        Casa casa = new Casa();
        Shader shader;


        //constructor
        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            init();
        }

        private void init()
        {
            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);  
            GL.BufferData(BufferTarget.ArrayBuffer, casa.verticesCount() * sizeof(float), casa.getVertices(), BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject); 
            GL.BufferData(BufferTarget.ElementArrayBuffer, casa.indexCount() * sizeof(uint), casa.getIndices(), BufferUsageHint.StaticDraw);

            //creamos y usamos el program shader
            string vertexPath = "Recursos/Shaders/VertexShader.glsl";
            string fragmentPath = "Recursos/Shaders/FragmentShader.glsl";

            shader = new Shader(vertexPath, fragmentPath);
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);


            //configuramos los atributos del vertexbuffer y lo habilitamos
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(0);

            shader.use();

            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.use();
            GL.BindVertexArray(VertexArrayObject);
            //Dibuja mi casa
            GL.DrawElements(PrimitiveType.Lines, casa.indexCount(), DrawElementsType.UnsignedInt, 0);

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
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            shader.Dispose(); //eliminamos el shader
            base.OnUnload(e);
        }
    }
}

