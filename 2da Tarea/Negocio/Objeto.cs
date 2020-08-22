using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Grafica_Project.Negocio
{
    class Objeto
    {

        //atributos

        public float[] positions;
        public uint[] indices;
        Color color;

        public Matrix4 model;
        public Matrix4 projection;
        public Matrix4 view;

        public int VertexBufferObject;
        public int VertexArrayObject;
        public int IndexBufferObject;
        public Shader shader;

        //constructor
        public Objeto()
        {
        }

        public void init(float[]pos, uint[] ind, Color color)
        {
            this.positions = pos;
            this.indices = ind;
            this.color = color;

            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, positions.Length * sizeof(float), positions, BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            //configuramos los atributos del vertexbuffer y lo habilitamos (el primer 0 indica el location en el vertexShader)
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);

            setColor();
        }


        //metodos principales
        private void setShader()
        {
            //creamos y usamos el program shader
            string vertexPath = "Recursos/Shaders/VertexShader.glsl";
            string fragmentPath = "Recursos/Shaders/FragmentShader.glsl";

            shader = new Shader(vertexPath, fragmentPath);
            shader.use();
        }

        public void setColor()
        {
            setShader();

            int locationColorUniform = GL.GetUniformLocation(shader.id, "u_Color");
            GL.Uniform4(locationColorUniform, color);
        }

        public void setMatrices(Matrix4 model, Matrix4 view, Matrix4 projection)
        {
            this.model = model;
            this.view = view;
            this.projection = projection;
        }

        private void setUniforms()
        {
            shader.setUniformMatrix4("model", model);
            shader.setUniformMatrix4("view", view);
            shader.setUniformMatrix4("projection", projection);
        }

        public void destroy()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            shader.Dispose(); //eliminamos el shader
        }

        public void dibujar()
        {
            //primero habilitamos todo
            shader.use();
            setUniforms();
            GL.BindVertexArray(VertexArrayObject);
            //Dibuja
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

        }


    }
}
