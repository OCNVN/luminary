using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Camaras
{
    public class CamaraAlrededor:CamaraBase
    {
        public CamaraAlrededor(): base(){ 
        }

        public void SetVista(float rotacionCamara, float arcoCamara, float distanciaCamara) {
            matrizVista = Matrix.CreateRotationY(MathHelper.ToRadians(rotacionCamara)) *
                          Matrix.CreateRotationX(MathHelper.ToRadians(arcoCamara)) *
                          Matrix.CreateLookAt(new Vector3(0, 22, distanciaCamara),
                                              new Vector3(0, 22, 0), Vector3.Up);

            matrizProyeccion = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                    aspectoRadio,
                                                                    1,
                                                                    10000);

        }

        public override void Actualizar(GameTime time)
        {
            
        }
    }
}
