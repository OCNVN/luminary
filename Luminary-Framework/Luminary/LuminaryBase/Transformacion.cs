using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase
{
    public class Transformacion
    {
        // Translacion
        Vector3 translacion;
        // Rotacion alrededor de (x,y,z) ejes del mundo
        Vector3 rotacion;
        // Escala en los ejes (x,y,z)
        Vector3 escala;
        bool nececitaActualizar;
        // Almacena la combinacion de las transformaciones
        Matrix matriz;

        public Vector3 Translacion {
            get { return translacion; }
            set { 
                translacion = value;
                nececitaActualizar = true;
            }
        }

        public Vector3 Rotacion {
            get { return rotacion; }
            set {
                rotacion = value;
                nececitaActualizar = true;
            }
        }

        public Vector3 Escala {
            get { return escala; }
            set {
                escala = value;
                nececitaActualizar = true;
            }
        }

        public Matrix Matriz {
            get {
                if (nececitaActualizar) { 
                    // Calcular la matriz final (Escala * Rotacion * Translacion)
                    matriz = Matrix.CreateScale(escala) *
                        Matrix.CreateRotationY(MathHelper.ToRadians(rotacion.Y)) *
                        Matrix.CreateRotationX(MathHelper.ToRadians(rotacion.X)) *
                        Matrix.CreateRotationZ(MathHelper.ToRadians(rotacion.Z)) *
                        Matrix.CreateTranslation(translacion);

                    nececitaActualizar = false;
                }
                return matriz;
            }
        }
    }
}
