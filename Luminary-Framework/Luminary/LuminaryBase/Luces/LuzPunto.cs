using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Luces
{
    public class LuzPunto:LuzBase
    {
        public static LuzPunto NoLight = new LuzPunto(Vector3.One, Vector3.Zero);

        Vector3 posicion;
        public Vector3 Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public LuzPunto(Vector3 posicion, Vector3 color)
            : base(color)
        {
            this.posicion = posicion;
        }
    }
}
