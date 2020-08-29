using OpenTK;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Grafica_Project.Negocio
{
    class Techo : Objeto
    {

        //atributos
        float[] vertices = new float[]
        {
            //posiciones
           -0.5f,  0.2f,  0.5f, // 0
            0.5f,  0.2f,  0.5f, // 1 
            0.0f,  0.7f,  0.5f, // 2

           -0.5f,  0.2f,  -0.5f, // 3
            0.5f,  0.2f,  -0.5f, // 4 
            0.0f,  0.7f,  -0.5f  // 5
        };

        uint[] indices = new uint[]
        {
            //cara delantera
            0, 1, 2,
            //cara derecha
            1, 4, 5,
            5, 2, 1,
            //cara de abajo
            1, 4, 3,
            3, 1, 0,
            //cara izquierda
            0, 3, 2,
            2, 3, 5,
            //cara de atras
            5, 3, 4

        };

        Color color = Color.FromArgb(207, 72, 43);

        //eje
        new float x =  0.0f;
        new float y = -0.45f;
        new float z =  0.0f;


        //constructor
        public Techo()
        {
            base.init(vertices, indices, color);
            base.setPosicionInicial(x, y, z);
        }

        public void descapotar()
        {

            Vector3 aux = new Vector3(0.0f, 0.0f, -0.02f);
            model = model * Matrix4.CreateTranslation(aux);
    
        }

    }
}
