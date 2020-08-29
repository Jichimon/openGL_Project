using OpenTK;
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

        //ejeCentral
        new float x = 0.0f;
        new float y = -0.4f;
        new float z =  0.51f;

        Vector3 ejeDeRotacion = new Vector3(-0.1f, -0.6f, 0.51f);


        //constructor
        public Puerta()
        {
            base.init(vertices, indices, color);
            base.setPosicionInicial(x, y, z);
        }

        public void openClose(float angle)
        {
            model = model * Matrix4.CreateTranslation(-ejeDeRotacion);
            rotar = Matrix4.CreateRotationY(angle);
            model = model * rotar;
            model = model * Matrix4.CreateTranslation(ejeDeRotacion);
        }
    }
}
