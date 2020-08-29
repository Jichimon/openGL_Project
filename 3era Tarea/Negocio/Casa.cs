using OpenTK;
using System.Collections.Generic;

namespace Grafica_Project.Negocio
{
    class Casa
    {

        //atributos
        List<Objeto> casa = new List<Objeto>();

        //constructor
        public Casa()
        {
            casa.Add(new Techo());
            casa.Add(new Puerta());
            casa.Add(new Pared());
        }

        public void setMatrices(Matrix4 model, Matrix4 view, Matrix4 projection)
        {
            foreach (Objeto parte in casa)
            {
                parte.setMatrices(model, view, projection);
            }
        }

        public void dibujar()
        {
            foreach (Objeto parte in casa)
            {
                parte.dibujar();
            }
        }

        public void rotarEnY(float angle)
        {
            foreach (Objeto parte in casa)
            {
                parte.rotateY(angle);
            }
        }

        public void rotarEnX(float angle)
        {
            foreach (Objeto parte in casa)
            {
                parte.rotateX(angle);
            }
        }

        public void rotarEnZ(float angle)
        {
            foreach (Objeto parte in casa)
            {
                parte.rotateZ(angle);
            }
        }

        public void puntoInicial()
        {
            foreach (Objeto parte in casa)
            {
                parte.puntoInicial();
            }
        }

        public void mover(Vector3 direccion)
        {
            foreach (Objeto parte in casa)
            {
                parte.mover(direccion);
            }
        }

        public void scale(Vector3 size)
        {
            foreach (Objeto parte in casa)
            {
                parte.scale(size);
            }
        }

        public void destroy()
        {
            foreach (Objeto parte in casa)
            {
                parte.destroy();
            }
        }

    }
}
