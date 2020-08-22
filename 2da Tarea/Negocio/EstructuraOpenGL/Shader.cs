using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Grafica_Project.Negocio
{
    class Shader
    {
        //atributos

        public int id; 
        private bool disposedValue = false;

        //constructor
        public Shader(string vertexPath, string fragmentPath)
        {
            int vertexShader, fragmentShader; //el id de cada shader

            //extraemos el codigo fuente de cada shader respectivamente
            string vertexShaderSource;
            using (StreamReader reader = new StreamReader(vertexPath))
            {
                vertexShaderSource = reader.ReadToEnd();
            }

            string fragmentShaderSource;
            using (StreamReader reader = new StreamReader(fragmentPath))
            {
                fragmentShaderSource = reader.ReadToEnd();
            }

            //compilamos cada shader
            vertexShader = compileShader(ShaderType.VertexShader, vertexShaderSource);
            fragmentShader = compileShader(ShaderType.FragmentShader, fragmentShaderSource);

            //creamos el programa y unimos los dos shaders
            id = GL.CreateProgram();

            GL.AttachShader(id, vertexShader);
            GL.AttachShader(id, fragmentShader);
            GL.LinkProgram(id);

            //limpiamos
            GL.DetachShader(id, vertexShader);
            GL.DetachShader(id, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);
        }

        private int compileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);  //generamos 
            GL.ShaderSource(shader, source); //unimos el shader generado al codigo fuente
            GL.CompileShader(shader); //compilamos

            //si hay algun error se verá en consola para debugging
            string infoLogVert = GL.GetShaderInfoLog(shader);
            if (infoLogVert != System.String.Empty)
                System.Console.WriteLine(infoLogVert);

            return shader;
        }


        public void use()
        {
            GL.UseProgram(id);
        }


        private int getUniformLocation(string name)
        {
            int location = GL.GetUniformLocation(id, name);
            if (location == -1)
                System.Console.WriteLine("Warning: uniform " + name + "no existe!");
            return location;
        }

        public void setUniformMatrix4(string name, Matrix4 matrix)
        {
            GL.UniformMatrix4(getUniformLocation(name), false, ref matrix);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(id);

                disposedValue = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(id);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
