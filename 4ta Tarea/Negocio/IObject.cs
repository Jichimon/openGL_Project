using OpenTK;

namespace Grafica_Project.Negocio
{
    interface IObject
    {
        void setPosicionInicial(float x, float y, float z);
        void puntoInicial();
        void mover(Vector3 direccion);
        void scale(Vector3 size);
        void rotateX(float angulo);
        void rotateY(float angulo);
        void rotateZ(float angulo);

    }
}
