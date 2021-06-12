using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Camaras
{
    public class AdministradorCamara
    {
        // Indice de la camara activa y referencia
        int indiceCamaraActiva;
        CamaraBase camaraActiva;
        // Lista ordenada conteniendo todas las camaras
        SortedList<string, CamaraBase> camaras;

        #region Propiedades
        public int IndiceCamaraActiva {
            get { return indiceCamaraActiva; }
        }

        public CamaraBase CamaraActiva {
            get { return camaraActiva; }
        }

        public CamaraBase this[int indice] {
            get { return camaras.Values[indice]; }
        }

        public CamaraBase this[string id] {
            get { return camaras[id]; }
        }

        public int Conteo {
            get { return camaras.Count; }
        }
        #endregion

        public AdministradorCamara() {
            camaras = new SortedList<string, CamaraBase>(4);
            indiceCamaraActiva = -1;
        }

        public void SetCamaraActiva(int indiceCamara) {
            indiceCamaraActiva = indiceCamara;
            camaraActiva = camaras[camaras.Keys[indiceCamara]];
        }

        public void SetCamaraActiva(string id) {
            indiceCamaraActiva = camaras.IndexOfKey(id);
            camaraActiva = camaras[id];
        }

        public void Clear() {
            camaras.Clear();
            camaraActiva = null;
            indiceCamaraActiva = -1;
        }

        public void Add(string id, CamaraBase camara) {
            camaras.Add(id, camara);
            if (camaraActiva == null) {
                camaraActiva = camara;
                indiceCamaraActiva = -1;
            }
        }

        public void Remove(string id) {
            camaras.Remove(id);
        }
    }
}
