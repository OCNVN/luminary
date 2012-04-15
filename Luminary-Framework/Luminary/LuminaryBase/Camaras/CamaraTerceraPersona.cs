using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Camaras
{
    public class CamaraTerceraPersona : CamaraBase
    {
        // Rotacion maxima permitida
        public static float ROTACION_MAXIMA = 30.0f;

        // Angulos de rotacion actuales sobre los ejes de la camara
        Vector3 ojoRotacion;

        // Velocidad de rotacion sobre los ejes de la camara
        Vector3 ojoRotacionVelocidad;
        public Vector3 OjoRotacionVelocidad {
            get { return ojoRotacionVelocidad; }
            set { ojoRotacionVelocidad = value; }
        }

        // Parametros personaje objetivo
        float distanciaPersonajeDeseada;
        float distanciaPersonajeMinima;
        float distanciaPersonajeMaxima;
        float personajeVelocidad;

        // Empezar seguimiento ahora
        bool esPrimeraVezPersonaje;

        Vector3 _posicionPersonaje;
        Vector3 posicionPersonaje {
            get { return _posicionPersonaje; }
            set { _posicionPersonaje = value; }
        }

        Vector3 _direccionPersonaje;
        Vector3 direccionPersonaje {
            get { return _direccionPersonaje; }
            set { _direccionPersonaje = value; }
        }

        public void SetPersonajeParametros(float personajeVelocidad,
            float distanciaPersonajeDeseada, float distanciaPersonajeMinima, float distanciaPersonajeMaxima){
                this.personajeVelocidad = personajeVelocidad;
                this.distanciaPersonajeDeseada = distanciaPersonajeDeseada;
                this.distanciaPersonajeMaxima = distanciaPersonajeMaxima;
                this.distanciaPersonajeMinima = distanciaPersonajeMinima;
        }

        private void ActualizarPosicionSeguimiento(float tiempoTranscurridoSegundos, bool interpolar) {
            Vector3 posicionObjetivo = posicionPersonaje;
            Vector3 posicionCamaraDeseada = posicionPersonaje - direccionPersonaje * distanciaPersonajeDeseada;
            if (interpolar) {
                float velocidadInterpolada = MathHelper.Clamp(personajeVelocidad * tiempoTranscurridoSegundos, 0.0f, 1.0f);
                posicionCamaraDeseada = Vector3.Lerp(Posicion, posicionCamaraDeseada, velocidadInterpolada);

                Vector3 vectorObjetivo = posicionCamaraDeseada - posicionObjetivo;
                float tamanoObjetivo = vectorObjetivo.Length();
                vectorObjetivo /= tamanoObjetivo;
                if (tamanoObjetivo < distanciaPersonajeMinima) {
                    posicionCamaraDeseada = posicionObjetivo + vectorObjetivo * distanciaPersonajeMinima;
                }
                else if (tamanoObjetivo > distanciaPersonajeMaxima) {
                    posicionCamaraDeseada = posicionObjetivo + vectorObjetivo * distanciaPersonajeMaxima;
                }
            }

            SetLookAt(posicionCamaraDeseada, posicionObjetivo, UpVector);
        }

        protected override void  ActualizarVista(){
            Vector3 nuevaPosicion = Posicion - Objetivo;

            // Calcular la nueva posicion de la camara, rotando alrededor de sus ejes
            nuevaPosicion = Vector3.Transform(nuevaPosicion,
                Matrix.CreateFromAxisAngle(UpVector, MathHelper.ToRadians(ojoRotacion.Y)) *
                Matrix.CreateFromAxisAngle(RightVector, MathHelper.ToRadians(ojoRotacion.X)) *
                Matrix.CreateFromAxisAngle(HeadingVector, MathHelper.ToRadians(ojoRotacion.Z)));

            matrizVista = Matrix.CreateLookAt(nuevaPosicion + Objetivo, Objetivo, UpVector);
            nececitaActualizarVista = false;
            nececitaActualizarFrustum = true;
        }

        public override void Actualizar(GameTime time)
        {
            float tiempoTranscurridoSegundos =(float) time.ElapsedGameTime.TotalSeconds;

            // Actualizar la posicion de seguimiento
            ActualizarPosicionSeguimiento(tiempoTranscurridoSegundos, !esPrimeraVezPersonaje);
            if (esPrimeraVezPersonaje) {
                ojoRotacion = Vector3.Zero;
                esPrimeraVezPersonaje = false;
            }

            // Calcular la nueva rotacion basado en la velocidadde rotacion
            if (ojoRotacionVelocidad != Vector3.Zero) {
                ojoRotacion += ojoRotacionVelocidad * tiempoTranscurridoSegundos;
                ojoRotacion.X = MathHelper.Clamp(ojoRotacion.X, -ROTACION_MAXIMA, ROTACION_MAXIMA);
                ojoRotacion.Y = MathHelper.Clamp(ojoRotacion.Y, -ROTACION_MAXIMA, ROTACION_MAXIMA);
                ojoRotacion.Z = MathHelper.Clamp(ojoRotacion.Z, -ROTACION_MAXIMA, ROTACION_MAXIMA);
                nececitaActualizarVista = true;
            }
        }
    }
}
