using OpenTK;
using System.Collections.Generic;

namespace Grafica_Project.Negocio
{
    class Casa
    {

        //atributos
        List<Objeto> casa = new List<Objeto>();
        Puerta puerta;
        Techo techo;
        Pared pared;

        //constructor
        public Casa()
        {
            techo = new Techo();
            puerta = new Puerta();
            pared = new Pared();
            casa.Add(techo);  // 0
            casa.Add(puerta); // 1
            casa.Add(pared);  // 2
        }

        public void setMatrices(Matrix4 view, Matrix4 projection)
        {
            foreach (Objeto parte in casa)
            {
                parte.setMatrices(view, projection);
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

        public void abrirCerrarPuerta(float angle)
        {
            foreach (Objeto parte in casa)
            {
                parte.moverAlPuntoInicial();
            }
            puerta.openClose(angle);
            foreach (Objeto parte in casa)
            {
                parte.volverAlPunto();
            }
        }

        public void descapotar()
        {
            foreach (Objeto parte in casa)
            {
                parte.moverAlPuntoInicial();
            }
            techo.descapotar();
            foreach (Objeto parte in casa)
            {
                parte.volverAlPunto();
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
