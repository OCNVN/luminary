using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Camaras
{
    public abstract class CamaraBase
    {
        // Proyeccion perspectiva
        float fovy;
        protected float aspectoRadio;
        float planoCercano;
        float planoLejano;

        // Matrices y flags
        protected bool nececitaActualizarProyeccion;
        protected bool nececitaActualizarFrustum;
        protected Matrix matrizProyeccion;
        protected bool nececitaActualizarVista;
        protected Matrix matrizVista;

        // Posicion y objetivo
        Vector3 posicion;
        Vector3 objetivo;
        
        // Vectores de orientacion
        Vector3 headingVec;
        Vector3 strafeVec;
        Vector3 upVec;

        // Frustum
        BoundingFrustum frustum;
        #region Propiedades
        public Matrix Proyeccion {
            get {
                if (nececitaActualizarProyeccion) ActualizarProyeccion();
                return matrizProyeccion;
            }
        }

        // Obtener la matriz de vista de la camara
        public Matrix Vista {
            get {
                if (nececitaActualizarVista) ActualizarVista();
                return matrizVista;
            }
        }

        public float FovY {
            get { return fovy; }
            set { 
                fovy = value;
                nececitaActualizarProyeccion = true;
            }
        }

        public float AspectoRadio {
            get { return aspectoRadio; }
            set {
                aspectoRadio = value;
                nececitaActualizarProyeccion = true;
            }
        }

        public float PlanoCercano {
            get { return planoCercano; }
            set { 
                planoCercano = value;
                nececitaActualizarProyeccion = true;
            }
        }

        public float PlanoLejano {
            get { return planoLejano; }
            set {
                planoLejano = value;
                nececitaActualizarProyeccion = true;
            }
        }

        public Vector3 Posicion {
            get { return posicion; }
            set {
                SetLookAt(value, objetivo, upVec);
            }
        }

        public Vector3 Objetivo {
            get { return objetivo; }
            set {
                SetLookAt(posicion, value, upVec);
            }
        }

        public Vector3 UpVector {
            get { return upVec; }
            set {
                SetLookAt(posicion, objetivo, value);
            }
        }

        public Vector3 HeadingVector {
            get { return headingVec; }
        }

        public Vector3 RightVector {
            get { return strafeVec; }
        }

        public BoundingFrustum Frustum {
            get {
                if (nececitaActualizarProyeccion) ActualizarProyeccion();
                if (nececitaActualizarVista) ActualizarVista();
                if (nececitaActualizarFrustum) ActualizarFrustum();
                return frustum;
            }
        }
        #endregion

        public CamaraBase() {
            setPerspectivaFov(45.0f, 1.0f, 0.1f, 10000.0f);
            SetLookAt(new Vector3(10.0f, 10.0f, 10.0f), Vector3.Zero, Vector3.Up);

            nececitaActualizarVista = true;
            nececitaActualizarProyeccion = true;
        }

        public void setPerspectivaFov(float fovy, float aspectoRadio, float planoCercano, float planoLejano) {
            this.fovy = fovy;
            this.aspectoRadio = aspectoRadio;
            this.planoCercano = planoCercano;
            this.planoLejano = planoLejano;
            nececitaActualizarProyeccion = true;
        }

        protected virtual void ActualizarProyeccion() { 
            // Crear un campo perspectiva de la matriz de vista
            matrizProyeccion = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(fovy), aspectoRadio, planoCercano, planoLejano);
            nececitaActualizarProyeccion = false;
            nececitaActualizarFrustum = true;
        }

        public void SetLookAt(Vector3 camaraPosicion, Vector3 camaraObjetivo, Vector3 camaraUp) {
            this.posicion = camaraPosicion;
            this.objetivo = camaraObjetivo;
            this.upVec = camaraUp;

            // Calcular los ejes de la camara
            headingVec = camaraObjetivo - camaraPosicion;
            headingVec.Normalize();
            upVec = camaraUp;
            strafeVec = Vector3.Cross(headingVec, upVec);
            nececitaActualizarVista = true;
        }

        protected virtual void ActualizarVista() {
            matrizVista = Matrix.CreateLookAt(posicion, objetivo, upVec);
            nececitaActualizarVista = false;
            nececitaActualizarFrustum = true;
        }

        protected virtual void ActualizarFrustum() {
            frustum = new BoundingFrustum(matrizVista * matrizProyeccion);
            nececitaActualizarFrustum = false;
        }

        public abstract void Actualizar(GameTime time);
    }
}
