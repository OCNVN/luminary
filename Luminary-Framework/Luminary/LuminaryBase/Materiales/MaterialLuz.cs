using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Materiales
{
    public class MaterialLuz
    {
        // Propiedades material (Difuso y Especular)
        Vector3 colorDifuso;
        Vector3 colorEspecular;
        float poderEspecular;

        public Vector3 ColorDifuso {
            get {
                return colorDifuso;
            }
            set {
                colorDifuso = value;
            }
        }

        public Vector3 ColorEspecular {
            get {
                return colorEspecular;
            }
            set {
                colorEspecular = value;
            }
        }

        public float PoderEspecular {
            get {
                return poderEspecular;
            }
            set {
                poderEspecular = value;
            }
        }

        public MaterialLuz() :this(new Vector3(1f),new Vector3(0.3f),8.0f)
        {     
        }

        public MaterialLuz(Vector3 colorDifuso, Vector3 colorEspecular, float poderEspecular) {
            this.colorDifuso = colorDifuso;
            this.colorEspecular = colorEspecular;
            this.poderEspecular = poderEspecular;
        }
    }
}
