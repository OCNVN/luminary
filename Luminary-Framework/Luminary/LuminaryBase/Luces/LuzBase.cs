using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Luces
{
    public abstract class LuzBase
    {
        // Luz color difuso y especular
        Vector3 color;
        public Vector3 Color
        {
            get { return color; }
            set { color = value; }
        }

        public LuzBase(Vector3 color)
        {
            this.color = color;
        }
    }
}
