
namespace Grafica_Project.Negocio
{
    class Casa
    {

        //atributos
        float[] vertices = new float[]
        {
            //posiciones
           -0.4f, -0.0f,  0.0f, // 0
           -0.4f, -0.4f,  0.0f, // 1 
            0.0f, -0.4f,  0.0f, // 2
            0.6f, -0.4f,  0.0f, // 3
            0.6f,  0.0f,  0.0f, // 4
            0.4f,  0.2f,  0.0f, // 5 
           -0.2f,  0.2f,  0.0f, // 6
            0.0f,  0.0f,  0.0f // 7

        };

        uint[] indices = new uint[]
        {
            //líneas
            0, 1,   1, 2,   2, 3,   
            3, 4,   4, 5,   4, 7,   
            7, 2,   5, 6,   6, 7,
            6, 0,   7, 0
        };



        //constructor
        public Casa()
        {
        }

        //getters
        public float[] getVertices()
        {
            return vertices;
        }

        public int verticesCount()
        {
            return vertices.Length;
        }

        public uint[] getIndices()
        {
            return indices;
        }

        public int indexCount()
        {
            return indices.Length;
        }

    }
}
