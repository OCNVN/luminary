using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace LuminaryFramework.LuminaryBase.Luces
{
    public class AdministradorLuz
    {
        // Componente global de luz ambiente en la escena
        Vector3 colorLuzAmbiente;
        // Almacenar una lista conteniendo todas las luces
        SortedList<string, LuzBase> luces;

        #region propiedades
        public Vector3 ColorLuzAmbiente {
            get { return colorLuzAmbiente; }
            set { colorLuzAmbiente = value; }
        }

        public LuzBase this[int indice] {
            get { return luces.Values[indice]; }
        }

        public LuzBase this[string id] {
            get { return luces[id]; }
        }

        public int Conteo {
            get { return luces.Count; }
        }
        #endregion

        public AdministradorLuz() {
            luces = new SortedList<string, LuzBase>();
        }

        public void Clear() {
            luces.Clear();
        }

        public void Add(string id, LuzBase luz) {
            luces.Add(id, luz);
        }

        public void Remove(string id) {
            luces.Remove(id);
        }
    }
}
