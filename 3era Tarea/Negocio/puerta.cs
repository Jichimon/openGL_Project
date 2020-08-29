using System.Drawing;

namespace Grafica_Project.Negocio
{
    class Puerta : Objeto
    {

        //atributos
        float[] vertices = new float[]
        {
            //posiciones
           -0.1f, -0.6f,   0.51f,  // 0
            0.1f, -0.6f,   0.51f,  // 1 
            0.1f, -0.2f,   0.51f,  // 2
           -0.1f, -0.2f,   0.51f,  // 3
        };

        uint[] indices = new uint[]
        {
            0, 1, 2,
            2, 3, 0
        };

        Color color = Color.FromArgb(119, 7, 9);



        //constructor
        public Puerta()
        {
            base.init(vertices, indices, color);
        }
    }
}
